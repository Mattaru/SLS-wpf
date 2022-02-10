using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using SLS.MVVM.View;
using SLS.Services.Interfaces;
using SLS.Services.Managers;
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

        static object? _currentView;

        public object? CurrentView { get => _currentView; set => Set(ref _currentView, value); }

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

        public MainVM(HomeVM Home, ResourcesListVM ResourceList, ILogger Logger)
        {
            #region View models

            Home.MainVM = this;

            ResourceList.MainVM = this;
            ResourceList.Logger = Logger;

            #endregion

            #region Commands

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
