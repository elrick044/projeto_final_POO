using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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

public class Aluno
{
    public Aluno()
    {
    }

    public Aluno(int? id, string nome, string login, string senha, List<Materia>? materias)
    {
        Id = id;
        Nome = nome;
        Login = login;
        Senha = senha;
        //Materias = materias;
        
        Materias = new List<Materia>();
        }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    
    public List<Materia>? Materias { get; set; }
    
    public override string ToString()
    {
        return $"Aluno: Id={Id}, Nome={Nome}, Login={Login}, Senha={Senha}";
    }
}

public class Materia
{
    public Materia()
    {
    }

    public Materia(int? id, string nome, int professorId, List<Aluno>? alunos, string chave)
    {
        Id = id;
        Nome = nome;
        ProfessorId = professorId;
        Alunos = alunos;
        Chave = chave;

        if (alunos == null)
        {
            Alunos = new List<Aluno>();    
        }
        
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Nome { get; set; }
    public List<Aluno> Alunos { get; set; }
    public string Chave { get; set; }
    
    public int ProfessorId { get; set; }
    [ForeignKey("ProfessorId")]
    public Professor Professor { get; set; }
    
    public List<Prova> Provas { get; set; }
    
    public override string ToString()
    {
        return $"Materia: Id={Id}, Nome={Nome}, ProfessorId={ProfessorId}, Chave={Chave}";
    }
}

public class Prova
{
    public Prova()
    {
    }

    public Prova(int? id, DateTime prazo, float peso, string nomeProva, int materiaId)
    {
        Id = id;
        Prazo = prazo;
        Peso = peso;
        NomeProva = nomeProva;
        MateriaId = materiaId;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public DateTime Prazo { get; set; }
    public float Peso { get; set; }
    public string NomeProva { get; set; }

    private int MateriaId { get; set; }
    [ForeignKey("MateriaId")]
    public Materia Materia { get; set; }
    
    public List<Questao> Questoes { get; set; }
    
    public override string ToString()
    {
        return $"Prova: Id={Id}, Prazo={Prazo}, Peso={Peso}, NomeProva={NomeProva}, MateriaId={MateriaId}";
    }
}

public class Questao
{
    public Questao()
    {
    }

    public Questao(int? id, string titulo, int provaId)
    {
        Id = id;
        Titulo = titulo;
        ProvaId = provaId;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Titulo { get; set; }
    private int ProvaId { get; set; }
    [ForeignKey("ProvaId")]
    public Prova Prova { get; set; }
    
    public List<Alternativa> Alternativas { get; set; }
    
    public override string ToString()
    {
        return $"Questao: Id={Id}, Titulo={Titulo}, ProvaId={ProvaId}";
    }
}

public class Alternativa
{
    public Alternativa()
    {
    }

    public Alternativa(int? id, string texto, bool correta, int questaoId)
    {
        Id = id;
        Texto = texto;
        Correta = correta;
        QuestaoId = questaoId;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    public string Texto { get; set; }
    public bool Correta { get; set; }
    
    public int QuestaoId { get; set; }
    [ForeignKey("QuestaoId")]
    
    public Questao Questao { get; set; }
    
    public override string ToString()
    {
        return $"Alternativa: Id={Id}, Texto={Texto}, Correta={Correta}, QuestaoId={QuestaoId}";
    }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Professor> Professor { get; set; } 
    public DbSet<Aluno> Aluno { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Prova> Provas { get; set; }
    public DbSet<Questao> Questoes { get; set; }
    public DbSet<Alternativa> Alternativas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=projeto_final_POO;Uid=root;Pwd=260405;"); 
    }
}
