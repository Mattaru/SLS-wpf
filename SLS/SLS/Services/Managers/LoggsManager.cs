using SLS.MVVM.Model;
using SLS.Services.Repositorys;
using System.Collections.ObjectModel;

namespace SLS.Services.Managers
{
    internal class LoggsManager
    {
        private LoggsRepository _Loggs;

        public ObservableCollection<LoggModel> Loggs => _Loggs.GetAll();

        public LoggsManager(LoggsRepository Loggs) => _Loggs = Loggs;

        public bool Add(LoggModel item)
        {
            if (item is null) return false;

            _Loggs.Add(item);

            return true;
        }
    }
}
