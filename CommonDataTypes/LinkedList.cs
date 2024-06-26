using System;

namespace CommonDataTypes
{
    public sealed class LinkedList<T>
    {
        public int Count { get; private set; }
        private ListNode<T> _root;
        private ListNode<T> _last;

        public LinkedList() { }

        public void Add(T item)
        {
            ListNode<T> newNode = new ListNode<T>(item);

            if(_root == null)
            {
                _root = newNode;
                _last = newNode;
            }
            else
            {
                newNode.NextConection(_last);
                _last = newNode;
            }

            Count++;
        }

        public void Insert(int index, T item)
        {
            if(index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();

            ListNode<T> newNode = new ListNode<T>(item);

            if (index == 0)
            {
                newNode.PrevConection(_root);
                _root = newNode;
            }
            else if(index == Count)
            {
                newNode.NextConection(_last);
                _last = newNode;
            }
            else
            {
                newNode.PrevConection(GetNodeByIndex(index));
            }

            Count++;
        }

        public void Remove(T item) => RemoveAt(IndexOf(item));

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                if (Count == 1)
                {
                    Clear();
                    return;
                }
                else
                {
                    _root = _root.Next;
                    _root.Prev = null;
                }
            }
            else if (index == Count-1)
            {
                _last = _last.Prev;
                _last.Next = null;
            }
            else
            {
                GetNodeByIndex(index).Disconect();
            }

            Count--;
        }

        public void Clear()
        {
            _root = null;
            _last = null;
            Count = 0;
        }

        public int IndexOf(T item)
        {
            int curentIndex = 0;
            ListNode<T> curentNode = _root;
            while (curentNode != null)
            {
                if(curentNode.Value.Equals(item))
                    return curentIndex;

                curentNode = curentNode.Next;
                curentIndex++;
            }

            return -1;
        }

        public T GetByIndex(int index) => GetNodeByIndex(index).Value;
        public void SetByIndex(int index, T value) => GetNodeByIndex(index).Value = value;

        private ListNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();

            int curentIndex = 0;
            ListNode<T> curentNode = _root;
            while (curentIndex != index)
            {
                curentNode = curentNode.Next;
                curentIndex++;
            }

            return curentNode;
        }
    }
}
