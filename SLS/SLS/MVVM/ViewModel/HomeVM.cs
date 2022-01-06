using SLS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.MVVM.ViewModel
{
    internal class HomeVM
    {
        public ObservableCollection<ResourceModel> ResourceModels { get; }

        public HomeVM()
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
