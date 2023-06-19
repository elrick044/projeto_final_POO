using System.ComponentModel.DataAnnotations.Schema;
public class Aluno
{
    public Aluno()
    {
    }

    public Aluno(int? id, string nome, string login, string senha, IEnumerable<AlunoMateria> alunosMaterias)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
        AlunosMaterias = alunosMaterias;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public IEnumerable<AlunoMateria>? AlunosMaterias { get; set; }

    public override string ToString()
    {
        return $"Aluno: Id={Id}, Nome={Nome}, Login={Login}, Senha={Senha}";
    }
}