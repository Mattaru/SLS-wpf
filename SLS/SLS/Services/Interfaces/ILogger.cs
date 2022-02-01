using SLS.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Services.Interfaces
{
    internal interface ILogger
    {
        public LoggModel AddedResource(string senderName);

        public  LoggModel AddedEmptyResource();

        public LoggModel RemovedResource(string senderName);

        public LoggModel ChangedResource(string senderName);
    }
}
