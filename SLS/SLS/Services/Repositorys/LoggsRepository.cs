using SLS.Core;
using SLS.MVVM.Model;
using SLS.TstingData;

namespace SLS.Services.Repositorys
{
    internal class LoggsRepository : RepositoryInMemory<LoggModel>
    {
        public LoggsRepository() : base(TestingData.Loggs) { }

        protected override void Update(LoggModel Source, LoggModel Destination)
        {
            throw new System.NotImplementedException("Method not implimented.");
        }
    }
}
