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

        public HomeV? HomeV { get; set; }

        public ResourcesListV? ResourcesListV { get; set; }

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

        private bool CanSelectHomeViewExecute(object p)
        {
            if (_currentView is HomeV)
                return false;

            return true;
        }

        private void OnSelectHomeViewExecuted(object p)
        {
            if (_currentView != null)
                CurrentView = HomeV;
        }

        #endregion

        #region SelectResourceListView COMMAND

        public ICommand SelectResourceListView { get; }

        private bool CanSelectResourceListViewExecute(object p)
        {
            if (_currentView is ResourcesListV)
                return false;

            return true;
        }

        private void OnSelectResourceListViewExecuted(object p)
        {
            if (_currentView != null)
                CurrentView = ResourcesListV;
        }

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

            HomeV = new HomeV();
            ResourcesListV = new ResourcesListV();

            CurrentView = HomeV;

            #endregion
        }
    }
}
