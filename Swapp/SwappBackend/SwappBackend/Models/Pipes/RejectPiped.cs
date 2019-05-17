using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwappBackend.Models.Pipes
{
    public class RejectPiped
    {
        public User User { get; set; }
        public string Message { get; set; }

        public RejectPiped(User user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
