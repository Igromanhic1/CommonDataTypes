using System;
using System.Collections;

namespace CommonDataTypes
{
    public sealed class List<T> : IList<T>, IEnumerator<T>
    {
        public int Count => _array.Length;
        public T Current => _array[_enumeratorIndex];
        object IEnumerator.Current => _array[_enumeratorIndex];
        public bool IsReadOnly => false;
        public T this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        private T[] _array;
        private int _enumeratorIndex;

        public bool Contains(T item) => IndexOf(item) != -1;

        public List()
        {
            _array = new T[0];
            Reset();
        }

        public void Add(T item)
        {
            T[] newArray = new T[Count + 1];

            CopyArrayTo(newArray);

            newArray[newArray.Length - 1] = item;
            _array = newArray;
        }

        public bool Remove(T item)
        {
            int indexOfElement = IndexOf(item);

            if (indexOfElement == -1)
                return false;

            RemoveAt(indexOfElement);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException();

            T[] newArray = new T[Count - 1];

            int indexNewArray = 0;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                    continue;

                newArray[indexNewArray] = _array[i];

                indexNewArray++;
            }

            _array = newArray;
        }

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0)
                throw new ArgumentOutOfRangeException();

            T[] newArray = new T[Count + 1];

            int indexOldArray = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if(i == index)
                {
                    newArray[i] = item;
                    continue;
                }

                newArray[i] = _array[indexOldArray];
                indexOldArray++;
            }

            _array = newArray;
        }

        public void Clear() => _array = new T[0];

        public int IndexOf(T key)
        {
            for (int i = 0; i < Count; i++)
                if (_array[i].Equals(key))
                    return i;
            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
                throw new ArgumentNullException();
            if(arrayIndex < 0)
                throw new ArgumentOutOfRangeException();

            for(int i = 0; i < Count; i++)
                array[i + arrayIndex] = array[i];
        }

        public IEnumerator<T> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => this;

        public bool MoveNext()
        {
            if(_enumeratorIndex < _array.Length - 1)
            {
                _enumeratorIndex++;
                return true;
            }

            return false;
        }

        public void Reset() => _enumeratorIndex = -1;

        public void Dispose()
        {
            Reset();
        }

        private void CopyArrayTo(T[] newArray)
        {
            for (int i = 0; i < Count && i < newArray.Length; i++)
                newArray[i] = _array[i];
        }
    }
}
