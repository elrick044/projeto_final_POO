public interface IRepository<T> where T : class
{
    T GetById(int id);
    List<T> GetAll();
    void Add(T entity);
    void Update(int id, T entity);
    void Delete(T entity);
}