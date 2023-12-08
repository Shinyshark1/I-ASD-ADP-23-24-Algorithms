namespace Algorithms.Hashtable
{
    public interface IHashtable<T>
    {
        public void Insert(string key, T value);
        public T Get(string key);
        public bool Delete(string key);
        public bool Update(string key, T value);
    }
}
