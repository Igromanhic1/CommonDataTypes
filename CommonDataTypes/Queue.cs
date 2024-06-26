using System;

namespace CommonDataTypes
{
    public sealed class Queue<T>
    {
        public int Count {  get; private set; }
        private StackNode<T> _root;
        private StackNode<T> _last;

        private Exception _emptyException => new Exception($"{nameof(Queue<T>)} is empty");

        public Queue() { }
        public Queue(IEnumerable<T> array)
        {
            foreach (T element in array)
                Push(element);
        }

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

            Count++;
        }

        public T Pop()
        {
            if (_root == null)
                throw _emptyException;

            T curentItem = _root.Value;
            _root = _root.Next;

            Count--;

            return curentItem;
        }

        public T Pick()
        {
            if (_root == null)
                throw _emptyException;

            return _root.Value;
        }

        public void Clean()
        {
            Count = 0;
            _root = null;
            _last = null;
        }
    }
}
