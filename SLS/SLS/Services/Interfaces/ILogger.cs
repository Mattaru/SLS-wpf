using SLS.Services.Logger;
using SLS.MVVM.Model;

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
