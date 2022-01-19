using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using SLS.TstingData;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class ResourcesListVM : ObservableObject
    {
        public MainVM? MainVM { get; internal set; }

        // Propertys

        public ObservableCollection<ResourceModel> Resources { get; }

        #region SelectedResource

        private ResourceModel? _SelectedResource;

        public ResourceModel SelectedResource {  get => _SelectedResource; set => Set<ResourceModel>(ref _SelectedResource, value); }

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

        private bool CanAddEmptyRecourceCommandExecute(object p) => Resources != null;

        private void OnAddEmptyRecourceCommandExecuted(object p) => Resources.Add(new ResourceModel());

        #endregion

        #region RemoveResourceCommand

        public ICommand RemoveResourceCommand { get; }

        private bool CanRemoveResourceCommandExecute(object p) => _SelectedResource != null;

        private void OnRemoveResourceCommandExecuted(object p) => Resources.Remove(SelectedResource);

        #endregion

        #region DataGridChangeVisibilityCommand

        public ICommand DataGridChangeVisibilityCommand { get; }

        private bool CanDataGridChangeVisibilityCommandExecute(object p) => _listBoxVisibility == "Visible";

        private void OnDataGridChangeVisibilityCommandExecuted(object p) 
        {
            _listBoxVisibility = "Collapsed";
            _dataGridVisibility = "Visible";
            OnPropertyChnged(nameof(DataGridVisibility));
            OnPropertyChnged(nameof(ListBoxVisibility));
            
        }

        #endregion

        #region ListBoxChangeVisibilityCommand

        public ICommand ListBoxChangeVisibilityCommand { get; }

        private bool CanListBoxChangeVisibilityCommandExecute(object p) => _dataGridVisibility == "Visible";

        private void OnListBoxChangeVisibilityCommandExecuted(object p) 
        {
            
            _dataGridVisibility = "Collapsed";
            _listBoxVisibility = "Visible";
            OnPropertyChnged(nameof(ListBoxVisibility));
            OnPropertyChnged(nameof(DataGridVisibility));
           
        }

        #endregion

        public ResourcesListVM()
        {
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

            var resources = TestingData.GetResourceList();
            Resources = new ObservableCollection<ResourceModel>(resources);

            // Filter for 'Search'
            SetSearchingFilters(Resources);
        }

        private void SetSearchingFilters(ObservableCollection<ResourceModel> Collection)
        {
            _selectedResourceCollection.Source = Collection;
            OnPropertyChnged(nameof(SelectedResourceCollection));
            _selectedResourceCollection.Filter += ResourceCollectionSearchFilter;
        }

        private void ResourceCollectionSearchFilter(object sender, FilterEventArgs e)
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
