using SLS.Core;
using SLS.MVVM.Model;
using SLS.TestingData;

namespace SLS.Services.Repositorys
{
    internal class LoggsRepository : RepositoryInMemory<LoggModel>
    {
        public LoggsRepository() : base(DataForTest.Loggs) { }

        protected override void Update(LoggModel Source, LoggModel Destination)
        {
            throw new System.NotImplementedException("Method not implimented.");
        }
    }
}
