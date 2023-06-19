using System.ComponentModel.DataAnnotations.Schema;

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
    public int ProvaId { get; set; }
    [ForeignKey("ProvaId")] public Prova Prova { get; set; }

    public List<Alternativa> Alternativas { get; set; }

    public override string ToString()
    {
        return $"Questao: Id={Id}, Titulo={Titulo}, ProvaId={ProvaId}";
    }
}