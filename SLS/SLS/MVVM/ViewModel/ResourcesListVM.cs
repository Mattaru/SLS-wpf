using SLS.Core;
using SLS.MVVM.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace SLS.MVVM.ViewModel
{
    internal class ResourcesListVM : ObservableObject
    {
        public ObservableCollection<ResourceModel> ResourceCollection { get; }

        public ResourcesListVM()
        {
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
