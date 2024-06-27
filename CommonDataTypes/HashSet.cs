using System;

namespace CommonDataTypes
{
    public sealed class HashSet<T>
    {
        public int Count { get; private set; }

        private LinkedList<LinkedList<T>> _chunks;

        public HashSet(int startChunksCount = 5)
        {
            UpdateChunksCount(startChunksCount);
        }

        public void Add(T item)
        {
            if (Contains(item))
                return;

            if (Count >= _chunks.Count)
                UpdateChunksCount(_chunks.Count * 2);

            AddTo(_chunks, item);
            Count++;
        }

        public void Remove(T item)
        {
            if (Contains(item))
            {
                RemoveFrom(_chunks, item);
                Count--;
            }
        }

        public bool Contains(T item) => _chunks[ComputeIndex(item, _chunks.Count)].IndexOf(item) != -1;

        private void UpdateChunksCount(int newSize)
        {
            LinkedList<LinkedList<T>> newChunks = new LinkedList<LinkedList<T>>();

            for(int i = 0; i < newSize; i++)
                newChunks.Add(new LinkedList<T>());

            if(_chunks != null)
            {
                Count = 0;
                foreach(LinkedList<T> list in _chunks)
                {
                    foreach(T item in list)
                    {
                        AddTo(newChunks, item);
                        Count++;
                    }
                }
            }

            _chunks = newChunks;
        }

        private void AddTo(LinkedList<LinkedList<T>> chunks, T item)
        {
            chunks[ComputeIndex(item, chunks.Count)].Add(item);
        }

        private bool RemoveFrom(LinkedList<LinkedList<T>> chunks, T item)
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

        private int ComputeIndex(T item, int chunksCount) => item.GetHashCode() % chunksCount;
    }
}
