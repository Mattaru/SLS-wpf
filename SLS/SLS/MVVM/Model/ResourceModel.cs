using SLS.MVVM.Model.Interfaces;
using System;

namespace SLS.MVVM.Model
{
    internal class ResourceModel : IEntity
    {
        private string _name = "Unknown";

        private string _login = "Unknown";

        private string _password = "Unknown";

        public int Id { get; set; }

        public string Name 
        { 
            get => _name;
            set
            {
                if (_name == value) return;

                _name = value;
                LastModificationDate = DateTime.Now;
            } 
        } 

        public string Login 
        { 
            get => _login;
            set
            {
                if (value == _login) return;    

                _login = value;
                LastModificationDate = DateTime.Now;
            } 
        }

        public string Password 
        { 
            get => _password;
            set
            {
                if (value != _password) return;

                _password = value;
                LastModificationDate = DateTime.Now;
            } 
        }

        public DateTime CreationDate { get; } = DateTime.Now;

        public DateTime LastModificationDate { get; private set; }

        public ResourceModel() { }

        public ResourceModel(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

    }
}
