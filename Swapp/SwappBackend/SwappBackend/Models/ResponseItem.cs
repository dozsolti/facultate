using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwappBackend.Models
{
    public class ResponseItem
    {
       
        public object data { get; set; }

        public string status { get; set; }

        public ResponseItem(string status, object data=null)
        {
            this.data = data;
            this.status = status;
        }
    }
}
