using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    T GetById(int id);
    List<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public class Repository<T> : IRepository<T> where T : class
{
    public ApplicationDbContext context;

    public Repository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public T GetById(int id)
    {
        return context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
        context.SaveChanges();
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }
}

public interface IProfessorRepository
{
    
}

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    
    public ProfessorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public bool login(string nome, string pass)
    {
        var professor = context.Professors.First(u => u.Nome == nome);//testar o que acontece quando não existe o nome  
        if (professor != null)
        {
            if (professor.Senha == pass)
            {
                return false;
            }
        }
        return false;
    }
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
