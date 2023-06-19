using System.Reflection.PortableExecutable;

namespace projeto_final_POO2.controllers;

public class SProva
{
    private readonly ProvaRepository _rp = new ProvaRepository();
    private readonly MateriaRepository _rm = new MateriaRepository();

    public void Add(Materia materia)
    {
        Console.WriteLine("--== DIGITE OS DADOS DA PROVA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Peso: ");
        float peso;
        while (!float.TryParse(Console.ReadLine(), out peso))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o peso: ");
        }

        Console.WriteLine("Prazo:");
        DateTime prazo;
        while (!DateTime.TryParse(Console.ReadLine(), out prazo))
        {
            Console.WriteLine("Entrada inválida. Digite uma data válida para o prazo: ");
        }

        Prova prova = new Prova(null, prazo, peso, nome, Convert.ToInt32(materia.Id));

        _rp.Add(prova);
    }

    public void Update(Prova p)
    {
        Console.WriteLine("--== DIGITE OS NOVOS DADOS DA PROVA: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Peso: ");
        float peso;
        while (!float.TryParse(Console.ReadLine(), out peso))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o peso: ");
        }

        Console.WriteLine("Prazo:");
        DateTime prazo;
        while (!DateTime.TryParse(Console.ReadLine(), out prazo))
        {
            Console.WriteLine("Entrada inválida. Digite uma data válida para o prazo: ");
        }

        Console.WriteLine("Id da Materia: ");
        int idm;
        while (!int.TryParse(Console.ReadLine(), out idm))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o ID da Materia: ");
        }

        Prova prova = new Prova(p.Id, prazo, peso, nome, p.MateriaId);

        _rp.Update(prova);
    }

    public void Delete(Prova prova)
    {
        _rp.Delete(prova);
    }

    public Prova GetByID(int id)
    {
        Prova prova = _rp.GetById(id);

        Console.WriteLine(prova.ToString());

        return prova;
    }

    public void GetByMaterias(Materia materia)
    {
        List<Prova> provas = _rp.GetByMateria(materia);

        foreach (var prova in provas)
        {
            Console.WriteLine(prova.ToString());
        }
    }

    public void GetAll()
    {
        List<Prova> provas = _rp.GetAll();

        foreach (var prova in provas)
        {
            Console.WriteLine(prova.ToString());
        }
    }
}
