using SLS.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SLS.MVVM.ViewModel
{
    internal class HomeVM : ObservableObject
    {
        //Propertys

        public ObservableCollection<String> HomePageLoggCollection { get; }

        #region ResourceFormTitle

        private string? _resourceFormTitle = "Just default Title";

        public string ResourceFormTitle { get => _resourceFormTitle; set => Set<string>(ref _resourceFormTitle, value); }

        #endregion

        #region Name

        private string? _name;

        public string Name { get => _name; set => Set<string>(ref _name, value); }

        #endregion

        #region Login

        private string? _login;

        public string Login { get => _login; set => Set<string>(ref _login, value); }

        #endregion

        #region Password

        private string? _password;

        public string Password { get => _password; set => Set<string>(ref _password, value); }

        #endregion

        public HomeVM()
        {
            var logs = Enumerable.Range(1, 100).Select(i => $"{DateTime.Now} | Event{i} | simple log string");
            HomePageLoggCollection = new ObservableCollection<String>(logs);
        }
    }
}
