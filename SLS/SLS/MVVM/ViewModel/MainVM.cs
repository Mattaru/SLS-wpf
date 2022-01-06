﻿using SLS.Core;
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
        #region App Title

        private string _title = "Default title.";

        public string Title { get => _title; set => Set<string>(ref _title, value); }

        #endregion

        public ObservableCollection<ResourceModel> ResourceCollection { get; }

        // Views

        #region Current view

        static object _currentView;

        public object CurrentView { get => _currentView; set => Set(ref _currentView, value); }

        #endregion

        // Commands

        #region Close app COMMAND

        public ICommand CloseApplicationCommand;

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p) => Application.Current.Shutdown();

        #endregion

        #region Maximaize app COMMAND

        public ICommand MaximizeAppCommand;

        private bool CanMaximizeAppCommandExecute(object p) => true;

        private void OnMaximizeAppCommandExecuted(object p) 
        {
            if(Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        #endregion

        #region Minimize app COMMAND

        public ICommand MinimizeAppCommand;

        private bool CanMinimizeAppCommandExecute(object p) => true;

        private void OnMinimizeAppCommandExecuted(object p) => Application.Current.MainWindow.WindowState = WindowState.Minimized;

        #endregion

        public MainVM()
        {
            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            MaximizeAppCommand = new LambdaCommand(OnMaximizeAppCommandExecuted, CanMaximizeAppCommandExecute);
            MinimizeAppCommand = new LambdaCommand(OnMinimizeAppCommandExecuted, CanMinimizeAppCommandExecute);

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
