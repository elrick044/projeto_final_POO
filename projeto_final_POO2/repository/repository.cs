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

public interface IAlunoMateriaRepository : IRepository<AlunoMateria>
{
    //implementar cabeçalhos
}

public class ProfessorRepository : Repository<Professor>, IProfessorRepository
{
    public Professor login(string login, string pass)
    {
        Professor professor = new Professor();

        try
        {
            professor = Context.Professor.First(u => u.Login == login);
        }
        catch (Exception e)
        {
            Console.WriteLine("Nome inválido");
            throw;
        }
        
        if (professor.Id != null)
        {
            if (professor.Senha != pass)
            {
                Console.WriteLine("Senha inválida");
                return null;
            }
            return professor;
        }

        return null;
    }
}

public class AlunoRepository : Repository<Aluno>, IAlunoRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();
    
    public Aluno login(string login, string pass)
    {
        Aluno aluno = null;
        try
        {
            aluno = Context.Aluno.First(u => u.Login == login);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Nome de usuario incorreto");
        }
        if (aluno != null)
        {
            if (aluno.Senha != pass)
            {
                Console.WriteLine("Senha incorreta");
                return null;
            }

            return aluno;
        }
        return null;
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
        return Context.Set<Prova>().Where(u => u.MateriaId == materia.Id).ToList();
    }
}


public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Questao> GetByProva(Prova prova)
    {
        return Context.Set<Questao>().Where(u => u.ProvaId == prova.Id).ToList();
    }
}

public class AlternativaRepository : Repository<Alternativa>, IAlternativaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Alternativa> GetByQuestao(Questao questao)
    {
        return Context.Set<Alternativa>().Where(u => u.QuestaoId == questao.Id).ToList();
    }
}

public class AlunoMateriaRepository : Repository<AlunoMateria>, IAlunoMateriaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();
    public List<AlunoMateria>getAllByIdAluno(int id)
    {
        return  Context.Set<AlunoMateria>().Where(u => u.IdAluno == id).ToList();
    }
}

//            professor = Context.Professor.First(u => u.Login == login);
