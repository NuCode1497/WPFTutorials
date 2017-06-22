using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    class Inventory : IList<Car>, INotifyCollectionChanged
    {
        private readonly IList<Car> _inventory;

        public Car this[int index]
        {
            get { return _inventory?[index]; }
            set
            {
                _inventory[index] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, _inventory[index]));
            }
        }

        public int Count => _inventory.Count;

        public bool IsReadOnly => _inventory.IsReadOnly;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Inventory(IList<Car> inventory)
        {
            _inventory = inventory;
        }

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }

        public void Add(Car item)
        {
            _inventory.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,item));
        }

        public void Clear()
        {
            _inventory.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(Car item) => _inventory.Contains(item);

        public void CopyTo(Car[] array, int arrayIndex) => _inventory.CopyTo(array, arrayIndex);

        public IEnumerator<Car> GetEnumerator() => _inventory.GetEnumerator();

        public int IndexOf(Car item) => _inventory.IndexOf(item);

        public void Insert(int index, Car item)
        {
            _inventory.Insert(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,item,index));
        }

        public bool Remove(Car item)
        {
            var removed = _inventory.Remove(item);
            if(removed)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            }
            return removed;
        }

        public void RemoveAt(int index)
        {
            var item = _inventory[index];
            _inventory.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
