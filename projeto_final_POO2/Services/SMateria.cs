namespace projeto_final_POO2.controllers;

public class SMateria
{
    private readonly MateriaRepository _rm = new MateriaRepository();
    private readonly ProfessorRepository _rp = new ProfessorRepository();

    public void Add(Professor p)
    {
        Console.WriteLine("--== DIGITE OS DADOS DO MATERIA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Chave: ");
        string chave = Console.ReadLine();

        Materia materia = new Materia(null, nome, Convert.ToInt32(p.Id), null, chave);

        _rm.Add(materia);
    }

    public void Update(Materia m)
    {
        Console.WriteLine("--== DIGITE OS NOVOS DADOS DO MATERIA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Chave: ");
        string chave = Console.ReadLine();

        Materia materia = new Materia(m.Id, nome, m.ProfessorId, m.AlunosMaterias, chave);

        _rm.Update(materia);
    }

    public void Delete(Materia materia)
    {
        _rm.Delete(materia);
    }

    public Materia GetByID(int id)
    {
        Materia materia = _rm.GetById(id);

        Console.WriteLine(materia);

        return materia;

    }

    public void GetAll(List<Materia>? materiasIncrito)
    {
        List<Materia> materias = _rm.GetAll();

        if (materiasIncrito != null)
        {
            materias.RemoveAll(valor => materiasIncrito.Contains(valor));
        }
        
        foreach (var materia in materias)
        {
            Console.WriteLine(materia.ToString());
        }
    }
    
}
