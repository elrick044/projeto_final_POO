namespace projeto_final_POO2.controllers;

public class SMateria
{
    private readonly MateriaRepository _rm = new MateriaRepository();
    private readonly ProfessorRepository _rp = new ProfessorRepository();
    
    public void Add(Professor p){
        Console.WriteLine("--== DIGITE OS DADOS DO MATERIA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Chave: ");
        string chave = Console.ReadLine();
        
        Materia materia = new Materia(null, nome, Convert.ToInt32(p.Id),null,  chave);

        _rm.Add(materia);
    }

    public void Update(Professor p)
    {
        Console.WriteLine("DIGITE O ID DA MATERIA A SER ALTERADA: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Materia m = _rm.GetById(id);

        Console.WriteLine("--== DIGITE OS NOVOS DADOS DO MATERIA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Chave: ");
        string chave = Console.ReadLine();
        
        Materia materia = new Materia(id, nome, Convert.ToInt32(p.Id), m.Alunos, chave);
        
        _rm.Update(materia);
    }

    public void Delete()
    {
        Console.WriteLine("DIGITE O ID DA MATERIA A SER DELETADA: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Materia materia = _rm.GetById(id);

        _rm.Delete(materia);
    }

    public void GetByID()
    {
        Console.WriteLine("DIGITE O ID DA MATERIA A SER IMPRESSA: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Materia materia = _rm.GetById(id);

        Console.WriteLine(materia.ToString());
    }

    public void GetAll()
    {
        List<Materia> materias = _rm.GetAll();

        foreach (var materia in materias)
        {
            Console.WriteLine(materia.ToString());
        }
    }

}