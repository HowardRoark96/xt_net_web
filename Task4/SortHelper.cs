using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task4
{
    class SortHelper<T>
    {
        private T[] _collection;

        public SortHelper(IEnumerable<T> collection)
        {
            _collection = collection.ToArray();
        }

        public event EventHandler<EventArgs> Sorted;

        public void ShowCollection()
        {
            foreach (var item in _collection)
            {
                Console.WriteLine(item);
            }
        }
        private void SortCollection(Func<T, T, bool> comparator)
        {
            T temp;

            for (int i = 0; i < _collection.Length; i++)
            {
                for (int j = i + 1; j < _collection.Length; j++)
                {
                    if (comparator(_collection[i], _collection[j]))
                    {
                        temp = _collection[i];
                        _collection[i] = _collection[j];
                        _collection[j] = temp;
                    }
                }
            }
        }
        public void SortCollectionWithEvent(Func<T, T, bool> comparator)
        {
            SortCollection(comparator);
            Sorted?.Invoke(_collection, EventArgs.Empty);
        }
        public void SortAsync(Func<T, T, bool> comparator)
        {
            Thread thread = new Thread(() =>
            {
                SortCollection(comparator);
                Sorted?.Invoke(_collection, EventArgs.Empty);
            });
            thread.Start();
        }
    }
}
