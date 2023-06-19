using System.ComponentModel.DataAnnotations.Schema;

public class Materia
{
    public Materia()
    {
    }

    public Materia(int? id, string nome, int professorId, IEnumerable<AlunoMateria> alunosMaterias, string chave)
    {
        Id = id;
        Nome = nome;
        ProfessorId = professorId;
        AlunosMaterias = alunosMaterias;
        Chave = chave;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string Nome { get; set; }
    public IEnumerable<AlunoMateria>? AlunosMaterias { get; set; }
    public string Chave { get; set; }

    public int ProfessorId { get; set; }
    [ForeignKey("ProfessorId")] public Professor Professor { get; set; }

    public List<Prova> Provas { get; set; }

    public override string ToString()
    {
        base.ToString();
        return $"{Id}, Nome= {Nome}, ProfessorId= {ProfessorId}";
    }
}