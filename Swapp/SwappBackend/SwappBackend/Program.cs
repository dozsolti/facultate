using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SwappBackend.Models;

namespace SwappBackend
{
    public class Program
    {
        /*
         * Conventii:
         * - in controller checkurile pt erori sunt in primele si doar apoi response success
         * - Serviceurile care modifica ceva (deci tot ce nu e GET) returneaza String.Empty la success sau string cu mesajul erorii
        * Usefull links:
        * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-2.2&tabs=visual-studio#add-a-crud-operations-class
        * https://msdn.microsoft.com/en-us/magazine/mt707525.aspx
        * https://www.devtrends.co.uk/blog/conditional-middleware-based-on-request-in-asp.net-core
        * 
        */
        public static string secretTokenKey = "so-secret";

        public static ResponseItem GetResponseItemFromError(string error, string successMessage)
        {
            if (!String.IsNullOrEmpty(error))
                return new ResponseItem("error", error);
            else
                return new ResponseItem("success", successMessage);
        }
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
