using System.ComponentModel.DataAnnotations.Schema;

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
    [ForeignKey("QuestaoId")] public Questao Questao { get; set; }

    public override string ToString()
    {
        return $"Alternativa: Id={Id}, Texto={Texto}, Correta={Correta}, QuestaoId={QuestaoId}";
    }
}