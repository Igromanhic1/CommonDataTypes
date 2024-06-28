using System;

namespace CommonDataTypes
{
    public sealed class Dictionary<TKey, TValue>
    {
        public int Count => _list.Count;

        private LinkedList<DictionaryItem<TKey, TValue>> _list;

        public Dictionary()
        {
            _list = new LinkedList<DictionaryItem<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value)
        {
            if (Contains(key))
                throw new ArgumentException();

            DictionaryItem<TKey, TValue> newItem = new DictionaryItem<TKey, TValue>(key,value);
            _list.Add(newItem);
        }

        public void Remove(TKey key)
        {
            DictionaryItem<TKey, TValue> item = GetByKey(key);

            if (item != null)
                _list.Remove(item);
        }

        public void RemoveAll(TValue value)
        {
            IEnumerable<DictionaryItem<TKey, TValue>> list = GetAllByValue(value);

            foreach(DictionaryItem<TKey, TValue> item in list)
                _list.Remove(item);
        }

        public void Clear() => _list.Clear();

        public bool Contains(TKey key) => GetByKey(key) != null;

        public TValue Get(TKey key)
        {
            DictionaryItem<TKey, TValue> item = GetByKey(key);

            if(item == null)
                throw new ArgumentException();

            return item.Value;
        }

        private DictionaryItem<TKey, TValue> GetByKey(TKey key)
        {
            foreach (DictionaryItem<TKey, TValue> item in _list)
                if (item.Key.Equals(key))
                    return item;

            return null;
        }

        private IEnumerable<DictionaryItem<TKey, TValue>> GetAllByValue(TValue value)
        {
            LinkedList<DictionaryItem<TKey, TValue>> items = new LinkedList<DictionaryItem<TKey, TValue>>();

            foreach (DictionaryItem<TKey, TValue> item in _list)
                if (item.Value.Equals(value))
                    items.Add(item);

            return items;
        }
    }
}
