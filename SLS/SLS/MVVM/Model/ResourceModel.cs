using SLS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.MVVM.Model
{
    internal class ResourceModel : ObservableObject
    {
        private string _name = "Unknown";
        public string Name { get => _name; set => Set<string>(ref _name, value); }


        private string _login = "Unknown";
        public string Login { get => _login; set => Set<string>(ref _login, value); }


        private string _password = "Unknown";
        public string Password { get => _password; set => Set<string>(ref _password, value); }


        public DateTime CreationDate { get; } = DateTime.Now;

        public DateTime LastModificationDate { get; private set; } = DateTime.Now;
    }
}
