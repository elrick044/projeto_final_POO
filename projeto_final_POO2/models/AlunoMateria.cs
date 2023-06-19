using System.ComponentModel.DataAnnotations.Schema;

public class AlunoMateria
{
    public AlunoMateria()
    {
    }
    
    public AlunoMateria(int idAluno, int idMateria, double nota)
    {
        IdAluno = idAluno;
        IdMateria = idMateria;
        Nota = nota;
    }

    public int IdAluno { get; set; }
    [ForeignKey("IdAluno")]
    public Aluno Aluno { get; set; }
    
    public int IdMateria { get; set; }
    [ForeignKey("IdMateria")]
    public Materia Materia { get; set; }
    
    public double Nota { get; set; }
}