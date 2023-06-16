namespace projeto_final_POO2.controllers;

public class SAluno
{

    private readonly AlunoRepository _ra = new AlunoRepository();

    public void Add(){
        Console.WriteLine("--== DIGITE OS DADOS DO ALUNO: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();
      
        Aluno aluno = new Aluno(null, nome, login, senha, null);

        _ra.Add(aluno);
    }

    public Aluno Login(){
        Console.WriteLine("--== LOGIN ==--");
        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();

        Aluno aluno = _ra.login(login, senha);

        return aluno;
    }
    
}