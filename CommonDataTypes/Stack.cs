using System;

namespace CommonDataTypes
{
    public sealed class Stack<T>
    {
        public int Count {  get; private set; }
        private StackNode<T> _root;

        private Exception _emptyException => new Exception($"{nameof(Stack<T>)} is empty");

        public Stack() { }

        public Stack(IEnumerable<T> array)
        {
            foreach(T element in array)
                Push(element);
        }

        public void Push(T item)
        {
            StackNode<T> newNode = new StackNode<T>(item);

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                newNode.Next = _root;
                _root = newNode;
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
        }
    }
}
