namespace LibraryAPI.Data.Repositories
{
    public interface ICrudRepository<T, U> //T and U are placeholders
    {
        // CRUD
        public IEnumerable<T> GetAll();
        public T Get(U id); //read
        public void Add(T element); //add
        public void Update(T element); //update
        public void Delete(U id); //delete

        public bool Save();
        public bool Exists (U id);
    }
}
