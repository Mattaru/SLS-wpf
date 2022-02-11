using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using SLS.Services.Interfaces;
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
        //Propertys

        private ResourcesManager _ResourceManager;

        private LoggsManager _LoggsManager;

        public MainVM? MainVM { get; internal set; }

        public ILogger Logger { get; internal set; }

        public ObservableCollection<LoggModel> Loggs { get; }

        public LoggModel? SelectedLoggModel { get; set; } 

        #region ResourceFormTitle

        public const string DEFAULT_FORM_TEXT = "Just default Title";

        private string? _resourceFormTitle = DEFAULT_FORM_TEXT;

        public string? ResourceFormTitle { get => _resourceFormTitle; set => Set(ref _resourceFormTitle, value); }

        #endregion

        #region Name

        private string? _name = string.Empty;

        public string? Name { get => _name; set => Set(ref _name, value); }

        #endregion

        #region Login

        private string? _login = string.Empty;

        public string? Login { get => _login; set => Set(ref _login, value); }

        #endregion

        #region Password

        private string? _password = string.Empty;

        public string? Password { get => _password; set => Set(ref _password, value); }

        #endregion

        // Commands

        #region AddResourceCommand

        public ICommand? AddResourceCommand { get; }

        private bool CanAddResourceCommandExecute(object p) => !(_ResourceManager is null);

        private void OnAddResourceCommandExecuted(object p)
        {
            if (CheckFormFields())
            {
                var resource = new ResourceModel(Name, Login, Password);
                var logg = Logger.AddedResource(Name);
                _ResourceManager.Add(resource);
                _LoggsManager.Add(logg);

                FormStatusMessage("Resource successfuly added.");
                ClearForm();
            }
        }

        #endregion

        public HomeVM(ResourcesManager ResourceManager, LoggsManager LoggsManager)
        {
            _ResourceManager = ResourceManager;
            _LoggsManager = LoggsManager;

            #region Commands

            AddResourceCommand = new LambdaCommand(OnAddResourceCommandExecuted, CanAddResourceCommandExecute);

            #endregion

            Loggs = _LoggsManager.Loggs;
            SelectedLoggModel = _LoggsManager.Loggs.LastOrDefault();
        }

        private void FormStatusMessage(string msg)
        {
            Task.Run(() =>
            {
                ResourceFormTitle = msg;

                Thread.Sleep(5000);

                ResourceFormTitle = DEFAULT_FORM_TEXT;
            });
        }

        private bool CheckFormFields()
        {
            if (Name == string.Empty && Login == string.Empty && Password == string.Empty)
                return false;

            if (Name == string.Empty)
            {
                FormStatusMessage("Enter resource name.");
                return false;
            }
            else if (Login == string.Empty)
            {
                FormStatusMessage("Enter resource login.");
                return false;
            }
            else if (Password == string.Empty)
            {
                FormStatusMessage("Enter resource password.");
                return false;
            }
            else
                return true;
        }

        private void ClearForm()
        {
            Name = string.Empty;
            Login = string.Empty;
            Password = string.Empty;

            OnPropertyChnged(nameof(Name));
            OnPropertyChnged(nameof(Login));
            OnPropertyChnged(nameof(Password));
        }
    }
}
