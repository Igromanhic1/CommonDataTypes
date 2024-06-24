namespace CommonDataTypes
{
    internal sealed class StackNode<T>
    {
        public T Value;
        public StackNode<T> Next;

        public StackNode(T value, StackNode<T> nextNode = null)
        {
            Value = value;
            Next = nextNode;
        }
    }
}
