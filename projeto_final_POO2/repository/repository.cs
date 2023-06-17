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
    
    public Professor login(string login, string pass)
    {
        Professor professor = new Professor(); 
        professor = Context.Professor.First(u => u.Login == login);//testar o que acontece quando não existe o nome  
        
        
        if (professor.Id != null)
        {
            if (professor.Senha != pass)
            {
                return null;
            }
            return professor;
        }

        return null;
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
    
    public Aluno login(string login, string pass)
    {
        var aluno = Context.Aluno.First(u => u.Login == login);//testar o que acontece quando não existe o nome  
        if (aluno != null)
        {
            if (aluno.Senha != pass)
            {
                return null;
            }

            return aluno;
        }
        return null;
    }

    public void subscribeClass(Materia materia, Aluno aluno)
    {
        if (GetById(Convert.ToInt32(aluno.Id)).Materias == null)
        {
            GetById(Convert.ToInt32(aluno.Id)).Materias = new List<Materia> { materia };
        }
        else
        {
            GetById(Convert.ToInt32(aluno.Id)).Materias.Add(materia);
        }
        Context.SaveChanges();
    }
}

public class MateriaRepository : Repository<Materia>, IMateriaRepository
{
}


public class ProvaRepository : Repository<Prova>, IProvaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Prova> GetByMateria(Materia materia)
    {
        return new List<Prova> { Context.Set<Prova>().Find(materia) };
    }
}


public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Questao> GetByProva(Prova prova)
    {
        return new List<Questao> { Context.Set<Questao>().Find(prova) };
    }
}

public class AlternativaRepository : Repository<Alternativa>, IAlternativaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Alternativa> GetByQuestao(Questao questao)
    {
        return new List<Alternativa> { Context.Set<Alternativa>().Find(questao) };
    }
}