namespace CommonDataTypes
{
    internal sealed class DictionaryItem <TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public DictionaryItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                throw new ArgumentNullException();

            if (obj is DictionaryItem<TKey, TValue> dict)
                return Key.Equals(dict.Key) && Value.Equals(dict.Value);
            else
                throw new InvalidDataException();
        }
    }
}
