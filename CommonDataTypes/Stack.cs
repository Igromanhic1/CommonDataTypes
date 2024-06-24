using System;

namespace CommonDataTypes
{
    public sealed class Stack<T>
    {
        public int Count => _count;

        private int _count;
        private StackNode<T> _root;

        public Stack() { }

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

            _count++;
        }

        public T Pop()
        {
            if (_root == null)
                throw new Exception("Stack is empty");

            T curentItem = _root.Value;
            _root = _root.Next;

            _count--;

            return curentItem;
        }

        public T Pick()
        {
            if (_root == null)
                throw new Exception("Stack is empty");

            return _root.Value;
        }
    }
}
