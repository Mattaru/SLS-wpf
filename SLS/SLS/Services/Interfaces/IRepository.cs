using SLS.MVVM.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace SLS.Services.Interfaces
{
    internal interface IRepository<T> where T : IEntity
    {
        void Add(T item);

        bool Remove(T item);

        void Update(int id, T item);

        ObservableCollection<T> GetAll();

        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
    }
}
