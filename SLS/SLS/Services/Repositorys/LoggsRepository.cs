using SLS.Core;
using SLS.MVVM.Model;
using SLS.TstingData;

namespace SLS.Services.Repositorys
{
    internal class LoggsRepository : RepositoryInMemory<LoggModel>
    {
        public LoggsRepository() : base(TestingData.Loggs) { }

        protected override bool Update(LoggModel Source, LoggModel Destination)
        {
            return false;
        }
    }
}
