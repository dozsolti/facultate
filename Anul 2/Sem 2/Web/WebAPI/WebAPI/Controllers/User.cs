using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set;}
        public string Password { get; set;}

        public List<Card> Cards { get; set; }

        public User(string username, string password, params Card[] cards)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Cards = cards.ToList();
        }
    }
}
