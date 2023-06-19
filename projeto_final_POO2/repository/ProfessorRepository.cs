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