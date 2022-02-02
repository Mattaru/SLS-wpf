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
        LoggModel AddedResource(string senderName);

        LoggModel AddedEmptyResource();

        LoggModel RemovedResource(string senderName);

        LoggModel ChangedResource(string senderName);
    }
}
