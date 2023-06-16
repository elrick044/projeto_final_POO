 using System.ComponentModel.DataAnnotations.Schema;
 using Microsoft.EntityFrameworkCore;

public class Professor
{
    public override string ToString()
    {
        return base.ToString();
    }

    public Professor(int id, string nome, string login, string senha)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}

public class Aluno
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    
    public List<Materia> Materias { get; set; }
}

public class Materia
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public Professor Professor { get; set; }
    public List<Aluno> Alunos { get; set; }
}

public class Prova
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Prazo { get; set; }
    public float Peso { get; set; }
    public string NomeProva { get; set; }
    public Materia Materia { get; set; }
}

public class Questao
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public float Peso { get; set; }
    public Prova Prova { get; set; }
}

public class Alternativa
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Texto { get; set; }
    public bool Correta { get; set; }
    public Questao Questao { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Professor> Alunos { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Prova> Provas { get; set; }
    public DbSet<Questao> Questoes { get; set; }
    public DbSet<Alternativa> Alternativas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=projeto_final_POO;Uid=root;Pwd=260405;"); 
    }
}