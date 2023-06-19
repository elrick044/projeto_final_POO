public class AlunoMateriaRepository : Repository<AlunoMateria>, IAlunoMateriaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();
    public List<AlunoMateria>getAllByIdAluno(int id)
    {
        return  Context.Set<AlunoMateria>().Where(u => u.IdAluno == id).ToList();
    }
    
    public AlunoMateria GetByIds(int idAluno, int idMateria)
    {
        return Context.Set<AlunoMateria>().FirstOrDefault(u => u.IdAluno == idAluno && u.IdMateria == idMateria);
    }

    public void Update(AlunoMateria entity)
    {
        Context.Entry(Context.Set<AlunoMateria>().FirstOrDefault(u=>u.IdAluno == entity.IdAluno && u.IdMateria == entity.IdMateria)).CurrentValues.SetValues(entity);
        Context.SaveChanges();
    }
}