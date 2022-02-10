using SLS.MVVM.Model;
using SLS.Services.Repositorys;
using System.Collections.ObjectModel;

namespace SLS.Services.Managers
{
    internal class ResourcesManager
    {
        private readonly ResourcesRepository _Resources;

        public ObservableCollection<ResourceModel> Resources => _Resources.GetAll();

        public ResourcesManager(ResourcesRepository ResourcesRepository) => _Resources = ResourcesRepository;

        public bool Add(ResourceModel Resource) 
        { 
            if (Resource is null) return false;

            _Resources.Add(Resource);

            return true;
        }

        public bool Delete(ResourceModel Resource) => _Resources.Remove(Resource);

        public void Update(ResourceModel Resource) => _Resources.Update(Resource.Id, Resource);
    }
}
