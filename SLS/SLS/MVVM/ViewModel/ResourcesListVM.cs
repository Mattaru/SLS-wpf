using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using SLS.Services.Interfaces;
using SLS.Services.Managers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class ResourcesListVM : ObservableObject
    {
        // Propertys

        public MainVM MainVM { get; internal set; }

        public ILogger Logger { get; internal set; }

        private ResourcesManager _ResourceManager;

        private LoggsManager _LoggsManager;

        #region SelectedResource

        private ResourceModel? _SelectedResource;

        public ResourceModel? SelectedResource 
        {  
            get => _SelectedResource;
            set
            { 
                Set(ref _SelectedResource, value);
                OnPropertyChnged(nameof(SelectedResource));
            } 
        }

        #endregion

        #region FilterString

        private string? _filterString;

        public string FilterString 
        {
            get => _filterString;
            set
            {
                if (value == _filterString) return;
                _filterString = value;
                OnPropertyChnged(nameof(_filterString));
                _selectedResourceCollection.View.Refresh();
            }
        }

        #endregion

        #region SelectedResourceCollection

        private readonly CollectionViewSource _selectedResourceCollection = new CollectionViewSource();

        public ICollectionView? SelectedResourceCollection => _selectedResourceCollection?.View;

        #endregion

        #region DataGridVisibility

        private string _dataGridVisibility;

        public string DataGridVisibility { get => _dataGridVisibility; set => Set(ref _dataGridVisibility, value); }

        #endregion

        #region ListBoxVisibility

        private string _listBoxVisibility;

        public string ListBoxVisibility { get => _listBoxVisibility; set => Set(ref _listBoxVisibility, value); }

        #endregion

        // Commands

        #region AddEmptyRecourceCommand

        public ICommand AddEmptyRecourceCommand { get; }

        private bool CanAddEmptyRecourceCommandExecute(object p) => true;

        private void OnAddEmptyRecourceCommandExecuted(object p)
        {
            
        }

        #endregion

        #region RemoveResourceCommand

        public ICommand RemoveResourceCommand { get; }

        private bool CanRemoveResourceCommandExecute(object p) => p is ResourceModel;

        private void OnRemoveResourceCommandExecuted(object p) 
        {
            var resource = (ResourceModel)p;

            _ResourceManager.Delete(resource);
            var logg = Logger.RemovedResource(resource.Name);
            _LoggsManager.Add(logg);
        }

        #endregion

        #region DataGridChangeVisibilityCommand

        public ICommand DataGridChangeVisibilityCommand { get; }

        private bool CanDataGridChangeVisibilityCommandExecute(object p) => _listBoxVisibility == "Visible";

        private void OnDataGridChangeVisibilityCommandExecuted(object p) 
        {
            ListBoxVisibility = "Collapsed";
            DataGridVisibility = "Visible";
            OnPropertyChnged(nameof(DataGridVisibility));
            OnPropertyChnged(nameof(ListBoxVisibility));
        }

        #endregion

        #region ListBoxChangeVisibilityCommand

        public ICommand ListBoxChangeVisibilityCommand { get; }

        private bool CanListBoxChangeVisibilityCommandExecute(object p) => _dataGridVisibility == "Visible";

        private void OnListBoxChangeVisibilityCommandExecuted(object p) 
        {
            DataGridVisibility = "Collapsed";
            ListBoxVisibility = "Visible";
            OnPropertyChnged(nameof(ListBoxVisibility));
            OnPropertyChnged(nameof(DataGridVisibility));
        }

        #endregion

        public ResourcesListVM(ResourcesManager ResourceManager, LoggsManager LoggsManager)
        {
            _ResourceManager = ResourceManager;
            _LoggsManager = LoggsManager;

            #region Commands

            AddEmptyRecourceCommand = new LambdaCommand(OnAddEmptyRecourceCommandExecuted, CanAddEmptyRecourceCommandExecute);
            RemoveResourceCommand = new LambdaCommand(OnRemoveResourceCommandExecuted, CanRemoveResourceCommandExecute);
            DataGridChangeVisibilityCommand = new LambdaCommand(OnDataGridChangeVisibilityCommandExecuted, CanDataGridChangeVisibilityCommandExecute);
            ListBoxChangeVisibilityCommand = new LambdaCommand(OnListBoxChangeVisibilityCommandExecuted, CanListBoxChangeVisibilityCommandExecute);

            #endregion

            #region Set default properties

            _dataGridVisibility = "Collapsed";
            _listBoxVisibility = "Visible";

            #endregion

            SetCollectionView(this._ResourceManager.Resources);
        }

        private void SetCollectionView(ObservableCollection<ResourceModel> Collection)
        {
            _selectedResourceCollection.Source = Collection;
            OnPropertyChnged(nameof(SelectedResourceCollection));
            _selectedResourceCollection.Filter += SetFilters;
        }

        private void SetFilters(object sender, FilterEventArgs e)
        {
            if (!(e.Item is ResourceModel resource))
            {
                e.Accepted = false;
                return;
            }

            var text = FilterString;
            if (string.IsNullOrWhiteSpace(text)) return;

            if (resource.Name is null || resource.Login is null || resource.Password is null)
            {
                e.Accepted |= false;
                return;
            }

            if (resource.Name.Contains(text, StringComparison.OrdinalIgnoreCase)) return;
            if (resource.Login.Contains(text, StringComparison.OrdinalIgnoreCase)) return;
            if (resource.Password.Contains(text, StringComparison.OrdinalIgnoreCase)) return;

            e.Accepted = false;
        }
    }
}
