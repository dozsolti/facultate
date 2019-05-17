using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwappBackend.Models
{
    public class Reject
    {
        public string UserId { get; set; }
        public string Message { get; set; }

        public Reject(string userId, string message)
        {
            UserId = userId;
            Message = message;
        }
    }
}
