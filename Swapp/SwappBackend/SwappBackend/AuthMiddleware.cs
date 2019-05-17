using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SwappBackend.Models;
using System;
using System.Threading.Tasks;

namespace SwappBackend
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMongoCollection<User> _users;

        public AuthMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            var client = new MongoClient(config.GetConnectionString("DBlink"));
            var database = client.GetDatabase("swapp");
            _users = database.GetCollection<User>("Users");
        }

        public Task Invoke(HttpContext httpContext)
        {
            if(runMiddleware(httpContext)==false)
                return _next(httpContext);

            try
            {
                string Authorization = httpContext.Request.Headers["Authorization"].ToString();

                if (Authorization.Length < "Bearer ".Length)
                    throw new Exception("Trebuie sa fii logat");

                string token = Authorization.Substring("Bearer ".Length);


                string[] splitedToken = token.Split("_");
                string tokenSecret = splitedToken[0];
                //codeul secret nu este acelas
                if (tokenSecret != Program.secretTokenKey)
                    throw new Exception("Wrong secret");

                //tokenul a expirat
                DateTime expirationDate = DateTime.Parse(splitedToken[2]);
                if (DateTime.Now > expirationDate)
                    throw new Exception( "Token expirat");

                //caut si returnez utilizatorul dorit, daca exista
                string userId = splitedToken[1];
                User user = _users.Find<User>(u => u.Id == userId).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("Utilizatorul nu exista");
                }

                httpContext.Items["token"] = token;
                httpContext.Items["user"] = user;
                return _next(httpContext);

            }catch(Exception ex)
            {
                return Handle(httpContext, ex);
            }
        }

        private static async Task Handle(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json; charset=utf-8";
            await httpContext.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new ResponseItem("error", ex.Message)));
            return;
        }

        private bool runMiddleware(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/api/private");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
