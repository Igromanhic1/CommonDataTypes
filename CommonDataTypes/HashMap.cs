using System;

namespace CommonDataTypes
{
    public sealed class HashMap<TKey, TValue>
    {
        public int Count { get; private set; }

        private LinkedList<LinkedList<DictionaryItem<TKey, TValue>>> _chunks;

        public HashMap(int startChunksCount = 5)
        {
            UpdateChunksCount(startChunksCount);
        }

        public void Add(TKey key, TValue value)
        {
            if (Contains(key))
                throw new ArgumentException();

            if (Count >= _chunks.Count)
                UpdateChunksCount(_chunks.Count * 2);

            AddTo(_chunks, new DictionaryItem<TKey, TValue>(key, value));
            Count++;
        }

        public void Remove(TKey key)
        {
            DictionaryItem<TKey,TValue> item = GetByKey(key);

            if (item != null)
            {
                RemoveFrom(_chunks, item);
                Count--;
            }
        }

        public void RemoveAll(TValue value)
        {
            foreach (DictionaryItem<TKey,TValue> item in GetByValue(value))
            {
                RemoveFrom(_chunks, item);
                Count--;
            }
        }

        public bool Contains(TKey key) => GetByKey(key) != null;

        public TValue Get(TKey key)
        {
            DictionaryItem<TKey, TValue> item = GetByKey(key);

            if (item == null)
                throw new ArgumentException();

            return item.Value;
        }

        private void UpdateChunksCount(int newChunksCount)
        {
            LinkedList<LinkedList<DictionaryItem<TKey, TValue>>> newChunks = new LinkedList<LinkedList<DictionaryItem<TKey, TValue>>>();

            for (int i = 0; i < newChunksCount; i++)
                newChunks.Add(new LinkedList<DictionaryItem<TKey, TValue>>());

            if (_chunks != null)
            {
                Count = 0;
                foreach (LinkedList<DictionaryItem<TKey, TValue>> list in _chunks)
                {
                    foreach (DictionaryItem<TKey, TValue> item in list)
                    {
                        AddTo(newChunks, item);
                        Count++;
                    }
                }
            }

            _chunks = newChunks;
        }

        private void AddTo(LinkedList<LinkedList<DictionaryItem<TKey, TValue>>> chunks, DictionaryItem<TKey, TValue> item)
        {
            chunks[ComputeIndex(item, chunks.Count)].Add(item);
        }

        private bool RemoveFrom(LinkedList<LinkedList<DictionaryItem<TKey, TValue>>> chunks, DictionaryItem<TKey, TValue> item)
        {
            int index = ComputeIndex(item, chunks.Count);
            int itemIndex = chunks[index].IndexOf(item);

            if (itemIndex != -1)
            {
                chunks[index].RemoveAt(itemIndex);
                return true;
            }

            return false;
        }

        private DictionaryItem<TKey, TValue> GetByKey(TKey key)
        {
            int chunkIndex = ComputeIndex(key, _chunks.Count);
            int index = _chunks[chunkIndex].SearchBy((x) => x.Key.Equals(key));

            if (index != -1)
                return _chunks[chunkIndex][index];
            else
                return null;
        }

        private IEnumerable<DictionaryItem<TKey, TValue>> GetByValue(TValue value)
        {
            LinkedList<DictionaryItem<TKey, TValue>> listItems = new LinkedList<DictionaryItem<TKey, TValue>>();

            foreach (LinkedList<DictionaryItem<TKey, TValue>> list in _chunks)
            {
                foreach(DictionaryItem<TKey, TValue> item in list)
                {
                    if(item.Value.Equals(value))
                        listItems.Add(item);
                }
            }

            return listItems;
        }

        private int ComputeIndex(DictionaryItem<TKey, TValue> item, int chunksCount) => ComputeIndex(item.Key, chunksCount);
        private int ComputeIndex(TKey key, int chunksCount) => Math.Abs(key.GetHashCode()) % chunksCount;
    }
}
