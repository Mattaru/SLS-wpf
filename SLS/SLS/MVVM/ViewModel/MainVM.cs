using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class MainVM : ObservableObject
    {
        public ObservableCollection<ResourceModel> ResourceCollection { get; }

        // Commands

        public ICommand CloseApplicationCommand;

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p) => Application.Current.Shutdown();


        public MainVM()
        {
            #region

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion

            var resources = Enumerable.Range(1, 100).Select(i => new ResourceModel
            {
                Name = $"Name {i}",
                Login = $"Login {i}",
                Password = $"Password {i}"
            });
            ResourceCollection = new ObservableCollection<ResourceModel>(resources);
        }
    }
}
