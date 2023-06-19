using System.ComponentModel.DataAnnotations.Schema;

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

    public int MateriaId { get; set; }
    [ForeignKey("MateriaId")] public Materia Materia { get; set; }

    public List<Questao> Questoes { get; set; }

    public override string ToString()
    {
        return $"{Id}, Prazo={Prazo}, Peso={Peso}, NomeProva={NomeProva}, MateriaId={MateriaId}";
    }
}