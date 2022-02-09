using SLS.MVVM.Model.Interfaces;
using SLS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SLS.Core
{
    abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        protected readonly ObservableCollection<T> _Items = new ObservableCollection<T>();

        protected int _lastId;

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach(var item in items)
                _Items.Add(item);
        }

        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (_Items.Contains(item)) return;

            _lastId = ++_lastId;
            _Items.Add(item);
        }

        public ObservableCollection<T> GetAll() => _Items;

        public bool Remove(T item) => _Items.Remove(item);

        public void Update(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), id, "ID can't be less then 1.");

            if (_Items.Contains(item)) return;

            var db_item = ((IRepository<T>) this).Get(id);
            if (db_item is null)
                throw new InvalidOperationException("Item can't be founded in the memory repository.");

            Update(item, db_item);
        }

        protected abstract bool Update(T Source, T Destination);
    }
}
