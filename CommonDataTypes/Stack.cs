﻿using System;

namespace CommonDataTypes
{
    public sealed class Stack<T>
    {
        public int Count => _count;

        private int _count;
        private StackNode<T> _root;

        private Exception _emptyExaption = new Exception($"{nameof(Stack<T>)} is empty");

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

            _count++;
        }

        public T Pop()
        {
            if (_root == null)
                throw _emptyExaption;

            T curentItem = _root.Value;
            _root = _root.Next;

            _count--;

            return curentItem;
        }

        public T Pick()
        {
            if (_root == null)
                throw _emptyExaption;

            return _root.Value;
        }

        public void Clean()
        {
            _count = 0;
            _root = null;
        }
    }
}
