namespace Hashing.Hashtables
{
    interface CommonHashtable<T, Y>
    {
        public bool Insert(T key, Y value);

        public Y Search(T key);

        public bool Delete(T key);
    }
}
