using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Utils
{
    public class MessageResult
    {
        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }


        public MessageResult(string message)
        {
            this.Message = message;
        }
    }


   
}
