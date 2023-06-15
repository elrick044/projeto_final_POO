using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<List<T>> GetAll();
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}

public interface IProfessorRepository : IRepository<Professor>
{
    // Métodos específicos para o Professor, se necessário
}

public interface IAlunoRepository : IRepository<Aluno>
{
    // Métodos específicos para o Aluno, se necessário
}

public interface IMateriaRepository : IRepository<Materia>
{
    // Métodos específicos para a Matéria, se necessário
}

public interface IProvaRepository : IRepository<Prova>
{
    // Métodos específicos para a Prova, se necessário
}

public interface IQuestaoRepository : IRepository<Questao>
{
    // Métodos específicos para a Questão, se necessário
}

public interface IAlternativaRepository : IRepository<Alternativa>
{
    // Métodos específicos para a Alternativa, se necessário
}

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    public ProfessorRepository(ApplicationDbContext context) : base(context)
    {
    }
}

public class AlunoRepository : Repository<Aluno>, IAlunoRepository
{
    public AlunoRepository(ApplicationDbContext context) : base(context)
    {
    }
}

public class MateriaRepository : Repository<Materia>, IMateriaRepository
{
    public MateriaRepository(ApplicationDbContext context) : base(context)
    {
    }
}

public class ProvaRepository : Repository<Prova>, IProvaRepository
{
    public ProvaRepository(ApplicationDbContext context) : base(context)
    {
    }
}

public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
{
    public QuestaoRepository(ApplicationDbContext context) : base(context)
    {
    }
}

public class AlternativaRepository : Repository<Alternativa>, IAlternativaRepository
{
    public AlternativaRepository(ApplicationDbContext context) : base(context)
    {
    }
}
