namespace StudentInformationSystem.Data.Abstract
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        List<T> GetAllT();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}
