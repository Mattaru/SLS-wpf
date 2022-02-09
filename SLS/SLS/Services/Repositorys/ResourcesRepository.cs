using SLS.Core;
using SLS.MVVM.Model;
using SLS.TstingData;
using System;

namespace SLS.Services.Repositorys
{
    internal class ResourcesRepository : RepositoryInMemory<ResourceModel>
    {
        public ResourcesRepository() : base(TestingData.Resources) { }

        protected override void Update(ResourceModel Source, ResourceModel Destination)
        {
            if (Source is null || Destination is null) 
                throw new ArgumentNullException($"One of arguments is null. {nameof(Source)} or {nameof(Destination)} is null.");

            Destination.Name = Source.Name;
            Destination.Login = Source.Login;
            Destination.Password = Source.Password;
        }
    }
}
