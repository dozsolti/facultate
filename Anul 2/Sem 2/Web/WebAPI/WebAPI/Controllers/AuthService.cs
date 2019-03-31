using System;
using System.Linq;

namespace WebAPI.Controllers
{
    internal class AuthService
    {
        private static string superSecretPassword = "so-secret";
        public static string GenerateToken(User user)
        {
            
            return superSecretPassword+"_" + user.Id + "_" + DateTime.Now.AddDays(3).ToString();
        }

        public static object DecodeToken(string token)
        {
            string[] splitedToken = token.Split("_");
            string tokenSecret = splitedToken[0];
            //codeul secret nu este acelas
            if (tokenSecret != superSecretPassword)
                return "Wrong secret";

            //tokenul a expirat
            DateTime expirationDate = DateTime.Parse(splitedToken[2]);
            if (DateTime.Now > expirationDate)
                return null;

            //caut si returnez utilizatorul dorit, daca exista
            Guid userId = new Guid(splitedToken[1]);
            User user = DB.users.FirstOrDefault(u => u.Id == userId);
            return user;
            /*if (i == -1)
                return "User not exists";
            return DB.users[i];*/

        }
    }
}