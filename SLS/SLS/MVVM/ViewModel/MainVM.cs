using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.View;
using System.Windows;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class MainVM : ObservableObject
    {
        // Views

        private readonly HomeV? HomeView;

        private readonly ResourcesListV? ResourcesListView;

        #region Current view

        static object _currentView;

        public object CurrentView { get => _currentView; set => Set(ref _currentView, value); }

        #endregion

        // General propertys

        #region App Title

        private string _appTitle = "Default title.";

        public string AppTitle { get => _appTitle; set => Set<string>(ref _appTitle, value); }

        #endregion

        #region App Subtitle

        private string _appSubtitle = "Simple subtitle";

        public string AppSubtitle { get => _appSubtitle; set => Set<string>(ref _appSubtitle, value); }

        #endregion

        // Commands

        #region CloseAppCommand

        public ICommand CloseAppCommand { get; }

        private bool CanCloseAppCommandExecute(object p) => true;

        private void OnCloseAppCommandExecuted(object p) => Application.Current.Shutdown();

        #endregion

        #region MaximizeAppCommand

        public ICommand MaximizeAppCommand { get; }

        private bool CanMaximizeAppCommandExecute(object p) => true;

        private void OnMaximizeAppCommandExecuted(object p) 
        {
            if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        #endregion

        #region MinimizeAppCommand

        public ICommand MinimizeAppCommand { get; }

        private bool CanMinimizeAppCommandExecute(object p) => true;

        private void OnMinimizeAppCommandExecuted(object p) => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        #endregion

        #region SelectHomeViewCommand

        public ICommand SelectHomeViewCommand { get; }

        private bool CanSelectHomeViewCommandExecute(object p)
        {
            if (CurrentView is HomeV)
                return false;
            return true;
        }

        private void OnSelectHomeViewCommandExecuted(object p) 
        {
            CurrentView = HomeView;
            OnPropertyChnged(nameof(CurrentView));
        }

        #endregion

        #region SelectResourceListView

        public ICommand SelectResourceListViewCommand { get; }

        private bool CanSelectResourceListViewCommandExecute(object p)
        {
            if (CurrentView is ResourcesListV)
                return false;
            return true;
        }

        private void OnSelectResourceListViewCommandExecuted(object p) 
        {
            CurrentView = ResourcesListView;
            OnPropertyChnged(nameof(CurrentView));
        } 

        #endregion

        public MainVM()
        {
            #region Commands

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            MaximizeAppCommand = new LambdaCommand(OnMaximizeAppCommandExecuted, CanMaximizeAppCommandExecute);
            MinimizeAppCommand = new LambdaCommand(OnMinimizeAppCommandExecuted, CanMinimizeAppCommandExecute);

            SelectHomeViewCommand = new LambdaCommand(OnSelectHomeViewCommandExecuted, CanSelectHomeViewCommandExecute);
            SelectResourceListViewCommand = new LambdaCommand(OnSelectResourceListViewCommandExecuted, CanSelectResourceListViewCommandExecute);

            #endregion

            #region Views

            HomeView = new HomeV();
            ResourcesListView = new ResourcesListV();

            CurrentView = HomeView;

            #endregion
        }
    }
}
