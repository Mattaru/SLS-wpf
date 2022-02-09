using SLS.MVVM.Model.Interfaces;
using System;

namespace SLS.MVVM.Model
{
    internal class ResourceModel : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Unknown";

        public string Login { get; set; } = "Unknown";

        public string Password { get; set; } = "Unknown";

        public DateTime CreationDate { get; } = DateTime.Now;

        public DateTime LastModificationDate { get; private set; } = DateTime.Now;
        
    }
}
