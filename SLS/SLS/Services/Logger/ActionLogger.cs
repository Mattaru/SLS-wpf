using SLS.Services.Logger;

namespace SLS.Services
{
    internal static class ActionLogger
    {
        private const string ADD_ACTION = "ADDED";

        private const string REMOVE_ACTION = "REMOVED";

        private const string CHANGED_ACTION = "CHANGED";

        private const string ADD_RESOURCE_MSG = "Has been added new resource.";

        private const string ADD_EMPTY_RESOURCE_MSG = "Has been added empty resource.";

        private const string REMOVE_RESOURCE_MSG = "Resource has been removed.";

        private const string CHANGED_RESOURCE_MSG = "Resource has been changed.";

        public static LoggModel AddedResource(string senderName) => new LoggModel(senderName, ADD_ACTION, ADD_RESOURCE_MSG);

        public static LoggModel AddedEmptyResource() => new LoggModel(ADD_ACTION, ADD_RESOURCE_MSG);

        public static LoggModel RemovedResource(string senderName) => new LoggModel(senderName, REMOVE_ACTION, REMOVE_RESOURCE_MSG);

        public static LoggModel ChangedResource(string senderName) => new LoggModel(senderName, CHANGED_ACTION, CHANGED_RESOURCE_MSG);
    }
}
