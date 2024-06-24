using System;

namespace CommonDataTypes
{
    public sealed class Queue<T>
    {
        public int Count => _count;

        private int _count;
        private StackNode<T> _root;
        private StackNode<T> _last;

        public void Push(T item)
        {
            StackNode<T> newNode = new StackNode<T>(item);

            if (_root == null)
            {
                _root = newNode;
                _last = newNode;
            }
            else
            {
                _last.Next = newNode;
                _last = _last.Next;
            }

            _count++;
        }

        public T Pop()
        {
            if (_root == null)
                throw new Exception("Queue is empty");

            T curentItem = _root.Value;
            _root = _root.Next;

            _count--;

            return curentItem;
        }

        public T Pick()
        {
            if (_root == null)
                throw new Exception("Queue is empty");

            return _root.Value;
        }
    }
}
