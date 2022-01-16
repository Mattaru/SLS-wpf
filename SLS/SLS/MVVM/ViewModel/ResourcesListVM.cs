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

        // Commands

        #region AddEmptyRecourceCommand

        public ICommand AddEmptyRecourceCommand { get; }

        private bool CanAddEmptyRecourceCommandExecute(object p) => true;

        private void OnAddEmptyRecourceCommandExecuted(object p) => Resources.Add(new ResourceModel());

        #endregion

        #region RemoveResourceCommand

        public ICommand RemoveResourceCommand { get; }

        private bool CanRemoveResourceCommandExecute(object p) => _SelectedResource != null;

        private void OnRemoveResourceCommandExecuted(object p) => Resources.Remove(SelectedResource);

        #endregion

        public ResourcesListVM()
        {
            #region Commands

            AddEmptyRecourceCommand = new LambdaCommand(OnAddEmptyRecourceCommandExecuted, CanAddEmptyRecourceCommandExecute);
            RemoveResourceCommand = new LambdaCommand(OnRemoveResourceCommandExecuted, CanRemoveResourceCommandExecute);

            #endregion

            var resources = Enumerable.Range(1, 100).Select(i => new ResourceModel
            {
                Name = $"Name {i}",
                Login = $"Login {i}",
                Password = $"Password {i}"
            });
            Resources = new ObservableCollection<ResourceModel>(resources);

            // Filter for 'Search'
            _selectedResourceCollection.Source = Resources;
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
