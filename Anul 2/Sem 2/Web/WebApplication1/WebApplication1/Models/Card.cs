using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Card
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public Card()
        {
            Id = Guid.NewGuid();
            Number = "";
        }
        public Card(string number)
        {
            Id = Guid.NewGuid();
            Number = number;
        }
    }
}
