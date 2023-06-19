public class ProvaRepository : Repository<Prova>, IProvaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Prova> GetByMateria(Materia materia)
    {
        return Context.Set<Prova>().Where(u => u.MateriaId == materia.Id).ToList();
    }
}