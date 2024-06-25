using System;

namespace CommonDataTypes
{
    public sealed class List<T>
    {
        public int Count => _array.Length;

        private T[] _array;

        public List()
        {
            _array = new T[0];
        }

        public void Add(T item)
        {
            T[] newArray = new T[Count+1];

            CopyArrayTo(newArray);

            newArray[newArray.Length-1] = item;
            _array = newArray;
        }

        public void Remove(T item)
        {
            int indexOfElement = Search(item);

            if (indexOfElement == -1)
                return;

            T[] newArray = new T[Count - 1];

            int indexNewArray = 0;
            for (int i = 0; i < Count; i++)
            {
                if (i == indexOfElement)
                    continue;

                newArray[indexNewArray] = _array[i];

                indexNewArray++;
            }

            _array = newArray;
        }

        public void Insert(T item, int index)
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

        public void Clean() => _array = new T[0];

        public T GetByIndex(int index) => _array[index];

        public T SetByIndex(int index, T value) => _array[index] = value;

        public int Search(T key)
        {
            for (int i = 0; i < Count; i++)
                if (_array[i].Equals(key))
                    return i;
            return -1;
        }

        private void CopyArrayTo(T[] newArray)
        {
            for (int i = 0; i < Count; i++)
                newArray[i] = _array[i];
        }
    }
}
