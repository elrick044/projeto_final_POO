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