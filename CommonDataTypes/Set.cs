using System;
using System.Collections.Generic;

namespace CommonDataTypes
{
    public sealed class Set<T>
    {
        public int Count => _array.Length;
        public T this[int index]
        {
            get
            {
                return _array[index];
            }
        }

        private T[] _array;

        public Set()
        {
            Clear();
        }

        public void Add(T item)
        {
            if (AreContains(item))
                throw new ArgumentException("Item is contains");

            T[] newArray = new T[Count + 1];

            for(int i = 0; i < Count; i++)
                newArray[i] = _array[i];

            newArray[newArray.Length-1] = item;

            _array = newArray;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
                return;

            T[] newArray = new T[Count - 1];

            int indexNewArray = 0;
            for (int i = 0; i < Count; i++)
            {
                if (index == i)
                    continue;

                newArray[indexNewArray] = _array[i];
                indexNewArray++;
            }

            _array = newArray;
        }

        public void Clear() => _array = new T[0];

        public int IndexOf(T item)
        {
            for(int i = 0; i < Count; i++)
                if (_array[i].Equals(item))
                    return i;

            return -1;
        }

        public bool AreContains(T item) => IndexOf(item) != -1;
    }
}
