using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Services.Logger
{
    internal class LoggModel
    {
        public string ObjectSenderName { get; } = "Unknown";

        public string Action { get; }

        public string Message { get; }

        public DateTime Date { get; }

        public LoggModel(string action, string messsage) 
        {
            Action = action;
            Message = messsage;
            Date = DateTime.Now;
        }

        public LoggModel(string senderName, string action, string message) : this(action, message)
        {
            ObjectSenderName = senderName;
        }
    }
}
