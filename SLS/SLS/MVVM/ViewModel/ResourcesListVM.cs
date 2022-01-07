using SLS.Core;
using SLS.Infrastucture.Commands;
using SLS.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SLS.MVVM.ViewModel
{
    internal class ResourcesListVM : ObservableObject
    {
        public ObservableCollection<ResourceModel> ResourceCollection { get; }

        #region SelectedResource

        private ResourceModel _SelectedResource;

        public ResourceModel SelectedResource { get => _SelectedResource; set => Set<ResourceModel>(ref _SelectedResource, value); }

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
            #region

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
        }
    }
}
