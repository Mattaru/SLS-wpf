using SLS.Core;
using SLS.MVVM.Model;
using SLS.TstingData;

namespace SLS.Services.Repositorys
{
    internal class ResourcesRepository : RepositoryInMemory<ResourceModel>
    {
        public ResourcesRepository() : base(TestingData.Resources) { }

        protected override bool Update(ResourceModel Source, ResourceModel Destination)
        {
            if (Source is null || Destination is null) return false;

            Destination.Name = Source.Name;
            Destination.Login = Source.Login;
            Destination.Password = Source.Password;

            return true;
        }
    }
}
