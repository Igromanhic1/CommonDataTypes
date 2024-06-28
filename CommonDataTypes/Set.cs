using System;
using System.Collections;

namespace CommonDataTypes
{
    public sealed class Set<T> : IEnumerator<T>, IEnumerable<T>
    {
        public int Count => _array.Length;
        public T Current => _array[_enumeratorIndex];
        public T this[int index]
        {
            get
            {
                return _array[index];
            }
        }

        private T[] _array;
        private int _enumeratorIndex;
        object IEnumerator.Current => _array[_enumeratorIndex];

        public Set()
        {
            Clear();
            Reset();
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

        public IEnumerator<T> GetEnumerator() => this;

        public bool MoveNext()
        {
            if (_enumeratorIndex < Count-1)
            {
                _enumeratorIndex++;
                return true;
            }

            return false;
        }

        public void Reset() => _enumeratorIndex = -1;

        public void Dispose() { }

        IEnumerator IEnumerable.GetEnumerator() => this;
    }
}
