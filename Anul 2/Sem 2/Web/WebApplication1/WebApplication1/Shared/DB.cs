using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Shared
{
    public static class DB
    {
        public static List<WebApplication1.Models.Card> cards = new List<WebApplication1.Models.Card>() {
            new Models.Card("4347 3091 9947 7380"),
            new Models.Card("4028 7900 8289 5554"),
            new Models.Card("4959 0310 6298 9932"),
        };

        static List<string[]> users = new List<string[]> { new string[] { "adam","1234","Adam" }, new string[] { "abc", "abc","John Doe" } };
        public static User loginedUser = null;
        public static bool isLogined
        {
            get
            {
                return loginedUser != null;
            }
        }

        public static void LogIn(User user)
        {
            loginedUser = user;
        }

        public static void Logout()
        {
            loginedUser = null;
        }

        public static User Login(string username, string password)
        {
            int i = users.FindIndex((string[] user) => user[0] == username && user[1] == password);

            if (i>-1)
                return new User(users[i]);
            else
                return null;
        }
    }
}
