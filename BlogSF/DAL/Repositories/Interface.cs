namespace BlogSF.DAL.Repositories
{
    public interface IBaseRepositories<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        void Create(T value);
        //void Read(int index, out T value);
        void Update(T value);
        void Delete(int id);
    }
}
