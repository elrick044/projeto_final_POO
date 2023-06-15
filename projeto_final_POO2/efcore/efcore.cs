 using Microsoft.EntityFrameworkCore;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    
    public List<Materia> Materias { get; set; }
}

public class Materia
{
    public int Id { get; set; }
    public string Nome { get; set; }
    //public int IdProfessor { get; set; }
    public Professor Professor { get; set; }
    
    public List<Aluno> Alunos { get; set; }
}

public class Prova
{
    public int Id { get; set; }
    //public int IdMateria { get; set; }
    public DateTime Prazo { get; set; }
    public float Peso { get; set; }
    public string NomeProva { get; set; }
    public Materia Materia { get; set; }
}

public class Questao
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public float Peso { get; set; }
    //public int IdProva { get; set; }
    public Prova Prova { get; set; }
}

public class Alternativa
{
    public int Id { get; set; }
    //public int IdQuestao { get; set; }
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