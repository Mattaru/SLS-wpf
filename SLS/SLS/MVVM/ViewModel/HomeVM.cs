using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using SLS.Services.Managers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class HomeVM : ObservableObject
    {
        public MainVM? MainVM { get; internal set; }

        //Propertys

        private ResourcesManager _ResourceManager;

        public ObservableCollection<String> HomePageLoggCollection { get; }


        #region ResourceFormTitle

        public const string DEFAULT_FORM_TEXT = "Just default Title";

        private string? _resourceFormTitle = DEFAULT_FORM_TEXT;

        public string ResourceFormTitle { get => _resourceFormTitle; set => Set(ref _resourceFormTitle, value); }

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

        // Commands

        #region AddResourceCommand

        public ICommand? AddResourceCommand { get; }

        private bool CanAddResourceCommandExecute(object p) => !(_ResourceManager is null);

        private void OnAddResourceCommandExecuted(object p)
        {
            if (Name is null || Login is null || Password is null) return;

            var resource = new ResourceModel(Name, Login, Password);
            _ResourceManager.Add(resource);

            

            Task.Run(() => 
            {
                ResourceFormTitle = "Resource successfuly added.";

                Thread.Sleep(5000);

                ResourceFormTitle = DEFAULT_FORM_TEXT;
            });

            Name = string.Empty;
            Login = string.Empty;
            Password = string.Empty;

            OnPropertyChnged(nameof(Name));
            OnPropertyChnged(nameof(Login));
            OnPropertyChnged(nameof(Password));
        }

        #endregion

        public HomeVM(ResourcesManager ResourceManager)
        {
            _ResourceManager = ResourceManager;

            #region Commands

            AddResourceCommand = new LambdaCommand(OnAddResourceCommandExecuted, CanAddResourceCommandExecute);

            #endregion

            var logs = Enumerable.Range(1, 100).Select(i => $"{DateTime.Now} | Event{i} | simple log string");
            HomePageLoggCollection = new ObservableCollection<String>(logs);
        }
    }
}
