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

    public void Update(T entity)
    {
        Context.Set<T>().Update(entity);
        Context.SaveChanges();
    }

    public void Delete(T entity)
    {
        Context.Set<T>().Remove(entity);
        Context.SaveChanges();
    }
}

public interface IProfessorRepository
{
    
}

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    
    public Professor login(string nome, string pass)
    {
        var professor = Context.Professor.First(u => u.Nome == nome);//testar o que acontece quando não existe o nome  
        if (professor != null)
        {
            if (professor.Senha == pass)
            {
                return null;
            }
        }
        return professor;
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
    public ApplicationDbContext Context = new ApplicationDbContext();
    
    public Aluno login(string nome, string pass)
    {
        var aluno = Context.Aluno.First(u => u.Nome == nome);//testar o que acontece quando não existe o nome  
        if (aluno != null)
        {
            if (aluno.Senha == pass)
            {
                return null;
            }
        }
        return aluno;
    }
}

public class MateriaRepository : Repository<Materia>, IMateriaRepository
{
}

public class ProvaRepository : Repository<Prova>, IProvaRepository
{
}

public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
{
}

public class AlternativaRepository : Repository<Alternativa>, IAlternativaRepository
{
}