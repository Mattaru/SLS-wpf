using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class MainVM : ObservableObject
    {
        #region App Title

        private string _title = "Default title.";

        public string Title { get => _title; set => Set<string>(ref _title, value); }

        #endregion

        // Views

        static HomeV? HomeView { get; set; }

        static ResourcesListV? ResourcesListView { get; set; }

        #region Current view

        static object _currentView;

        public object CurrentView { get => _currentView; set => Set(ref _currentView, value); }

        #endregion

        // Commands

        #region CloseAppCommand COMMAND

        public ICommand CloseAppCommand { get; }

        private bool CanCloseAppCommandExecute(object p) => true;

        private void OnCloseAppCommandExecuted(object p) => Application.Current.Shutdown();

        #endregion

        #region MaximizeAppCommand COMMAND

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

        #region MinimizeAppCommand COMMAND

        public ICommand MinimizeAppCommand { get; }

        private bool CanMinimizeAppCommandExecute(object p) => true;

        private void OnMinimizeAppCommandExecuted(object p) => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        #endregion

        #region SelectHomeView COMMAND

        public ICommand SelectHomeView { get; }

        private bool CanSelectHomeViewExecute(object p) => true;

        private void OnSelectHomeViewExecuted(object p) => CurrentView = HomeView;

        #endregion

        #region SelectResourceListView COMMAND

        public ICommand SelectResourceListView { get; }

        private bool CanSelectResourceListViewExecute(object p) => true;

        private void OnSelectResourceListViewExecuted(object p) => CurrentView = ResourcesListView;

        #endregion

        public MainVM()
        {
            #region Commands

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            MaximizeAppCommand = new LambdaCommand(OnMaximizeAppCommandExecuted, CanMaximizeAppCommandExecute);
            MinimizeAppCommand = new LambdaCommand(OnMinimizeAppCommandExecuted, CanMinimizeAppCommandExecute);

            SelectHomeView = new LambdaCommand(OnSelectHomeViewExecuted, CanSelectHomeViewExecute);
            SelectResourceListView = new LambdaCommand(OnSelectResourceListViewExecuted, CanSelectResourceListViewExecute);

            #endregion

            #region Views

            HomeView = new HomeV();
            ResourcesListView = new ResourcesListV();

            CurrentView = HomeView;

            #endregion
        }
    }
}
