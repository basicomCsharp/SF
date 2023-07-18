namespace BlogSF.DAL.Repositories
{
    public interface IBaseRepositories<T>
    {       
        public bool Create(T value);
        public bool Read(int index, out T value);
        public bool Update(T value);
        public bool Delete(T value);                    
    }
}
