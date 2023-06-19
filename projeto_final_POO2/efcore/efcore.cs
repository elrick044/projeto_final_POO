using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Professor> Professor { get; set; }
    public DbSet<Aluno> Aluno { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Prova> Provas { get; set; }
    public DbSet<Questao> Questoes { get; set; }
    public DbSet<Alternativa> Alternativas { get; set; }
    public DbSet<AlunoMateria> AlunosMaterias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=projeto_final_POO;Uid=root;Pwd=260405;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AlunoMateria>()
            .HasKey(m => new { m.IdAluno, m.IdMateria });
        
        modelBuilder.Entity<AlunoMateria>()
            .HasOne(m => m.Aluno)
            .WithMany(a => a.AlunosMaterias)
            .HasForeignKey(m => m.IdAluno);

        modelBuilder.Entity<AlunoMateria>()
            .HasOne(m => m.Materia)
            .WithMany(d => d.AlunosMaterias)
            .HasForeignKey(m => m.IdMateria);
    }
}