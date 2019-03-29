using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class User
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public User(string[] data)
        {
            this.Username = data[0];
            this.Name = data[1];
        }
    }
}
