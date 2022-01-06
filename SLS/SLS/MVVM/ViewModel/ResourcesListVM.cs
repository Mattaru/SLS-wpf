using SLS.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace SLS.MVVM.ViewModel
{
    internal class ResourcesListVM
    {
        public ObservableCollection<ResourceModel> ResourceModels { get; }

        public ResourcesListVM()
        {
            var resources = Enumerable.Range(1, 100).Select(i => new ResourceModel
            {
                Name = $"Name {i}",
                Login = $"Login {i}",
                Password = $"Password {i}"
            });

            ResourceModels = new ObservableCollection<ResourceModel>(resources);
        }
    }
}
