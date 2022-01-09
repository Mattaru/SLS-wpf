using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class ResourcesListVM : ObservableObject
    {
        public ObservableCollection<ResourceModel> ResourceCollection { get; }

        #region SelectedResource

        private ResourceModel? _SelectedResource;

        public ResourceModel SelectedResource {  get => _SelectedResource; set => Set<ResourceModel>(ref _SelectedResource, value); }

        #endregion

        #region FilterString

        private string _filterString;

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

        // Commands

        #region AddEmptyRecource COMMAND

        public ICommand AddEmptyRecource { get; }

        private bool CanAddEmptyRecourceExecute(object p) => true;

        private void OnAddEmptyRecourceExecuted(object p) => ResourceCollection.Add(new ResourceModel());

        #endregion

        #region RemoveResource COMMAND

        public ICommand RemoveResource { get; }

        private bool CanRemoveResourceExecute(object p) => _SelectedResource != null;

        private void OnRemoveResourceExecuted(object p) => ResourceCollection.Remove(SelectedResource);

        #endregion

        public ResourcesListVM()
        {
            #region Commands

            AddEmptyRecource = new LambdaCommand(OnAddEmptyRecourceExecuted, CanAddEmptyRecourceExecute);
            RemoveResource = new LambdaCommand(OnRemoveResourceExecuted, CanRemoveResourceExecute);

            #endregion

            var resources = Enumerable.Range(1, 100).Select(i => new ResourceModel
            {
                Name = $"Name {i}",
                Login = $"Login {i}",
                Password = $"Password {i}"
            });

            ResourceCollection = new ObservableCollection<ResourceModel>(resources);

            // Filter for 'Search'
            _selectedResourceCollection.Source = ResourceCollection;
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
