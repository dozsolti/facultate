using System;

namespace WebAPI.Controllers
{
    internal class AuthService
    {
        private static string superSecretPassword = "so-secret";
        public static string GenerateToken(User user)
        {
            
            return superSecretPassword+"_" + user.Id + "_" + DateTime.Now.Add(new TimeSpan(3,0,0,0)).ToString();
        }

        public static object DecodeToken(string token)
        {
            string[] splitedToken = token.Split("_");
            string tokenSecret = splitedToken[0];
            //codeul secret nu este acelas
            if (tokenSecret != superSecretPassword)
                return "Wrong secret";

            //tokenul a expirat
            /*DateTime tokenExpiration = DateTime.Now;//new DateTime(splitedToken[1]);
            if(DateTime.Now>=tokenExpiration)
                return null;*/

            //caut si returnez utilizatorul dorit, daca exista
            Guid userId = new Guid(splitedToken[1]);
            int i = DB.users.FindIndex(u => u.Id == userId);
            if (i == -1)
                return "User not exists";
            return DB.users[i];

        }
    }
}