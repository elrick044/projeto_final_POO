using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    public ApplicationDbContext Context = new ApplicationDbContext();
    
    public T GetById(int id)
    {
        return Context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return Context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        Context.Set<T>().Add(entity);
        Context.SaveChanges();
    }

    public void Update(int id, T newEntidade)
    {
        Context.Entry(Context.Set<T>().Find(id)).CurrentValues.SetValues(newEntidade);
        Context.SaveChanges();
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
        Context.SaveChanges();
    }
}













