using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public static class DB
    {
        public static List<User> users = new List<User>()
        {
            new User("abc","123",
                    new Card[] {
                        new Card("1234-1234-1234-1234"),
                        new Card("1004-0000-1200-1234")
                    }
               )
        };

        public static User Login(string username, string password)
        {
            int i = users.FindIndex(u => u.Username==username && u.Password == password);
            if (i == -1)
                return null;
            return users[i];
        }
    }
}
