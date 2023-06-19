using System.ComponentModel.DataAnnotations.Schema;

public class Professor
{
    public Professor()
    {
    }

    public Professor(int? id, string nome, string login, string senha)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public List<Materia> Materias { get; set; }

    public override string ToString()
    {
        return $"Professor: Id={Id}, Nome={Nome}, Login={Login}, Senha={Senha}";
    }
}