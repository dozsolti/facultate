using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }

        public Card(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }
    }
}
