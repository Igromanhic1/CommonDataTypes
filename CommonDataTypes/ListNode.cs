using System;

namespace CommonDataTypes
{
    internal sealed class ListNode<T>
    {
        public T Value;
        public ListNode<T> Next;
        public ListNode<T> Prev;

        public ListNode(T value, ListNode<T> next = null, ListNode<T> prev = null)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }

        public void NextConection(ListNode<T> parent)
        {
            if (parent.Next == null)
            {
                Prev = parent;
                parent.Next = this;
            }
            else
            {
                ListNode<T> parentNext = parent.Next;

                Prev = parent;
                parent.Next = this;

                Next = parentNext;
                parentNext.Prev = this;
            }
        }

        public void PrevConection(ListNode<T> parent)
        {
            if (parent.Prev == null)
            {
                Next = parent;
                parent.Prev = this;
            }
            else
            {
                ListNode<T> parentPrev = parent.Prev;

                Next = parent;
                parent.Prev = this;

                Prev = parentPrev;
                parentPrev.Next = this;
            }
        }

        public void Disconect()
        {
            if(Next != null)
            {
                Next.Prev = Prev;
            }

            if(Prev != null)
            {
                Prev.Next = Next;
            }
        }
    }
}
