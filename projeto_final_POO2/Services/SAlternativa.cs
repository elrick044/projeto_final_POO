namespace projeto_final_POO2.controllers;

public class SAlternativa
{
    private readonly AlternativaRepository _ra = new AlternativaRepository();
    private readonly QuestaoRepository _rq = new QuestaoRepository();
    
    public void Add(){
        Console.WriteLine("--== DIGITE OS DADOS DA ALTERNATIVA: ==--");
        Console.WriteLine("Texto:");
        string texto = Console.ReadLine();
        
        Console.WriteLine("Correta:");
        bool correta = Convert.ToBoolean(Console.ReadLine());
        
        Console.WriteLine("Id da Prova: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Questao questao = _rq.GetById(id);

        Alternativa alternativa = new Alternativa(null, texto, correta, Convert.ToInt32(questao.Id));

        _ra.Add(alternativa);
    }

    public void Update()
    {
        Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER ALTERADA: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("--== DIGITE OS NOVOS DADOS DA ALTERNATIVA: ==--");
        Console.WriteLine("Texto:");
        string texto = Console.ReadLine();
        
        Console.WriteLine("Correta:");
        bool correta = Convert.ToBoolean(Console.ReadLine());
        
        Console.WriteLine("Id da Prova: ");
        int idq = Convert.ToInt32(Console.ReadLine());

        Questao questao = _rq.GetById(idq);

        Alternativa alternativa = new Alternativa(id, texto, correta, Convert.ToInt32(questao.Id));

        _ra.Update(alternativa);
    }

    public void Delete()
    {
        Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER DELETADA: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Alternativa alternativa = _ra.GetById(id);

        _ra.Delete(alternativa);
    }

    public void GetByID()
    {
        Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER IMPRESSA: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Alternativa alternativa = _ra.GetById(id);

        Console.WriteLine(alternativa.ToString());
    }

    public void GetAll()
    {
        List<Alternativa> alternativas = _ra.GetAll();

        foreach (var alternativa in alternativas)
        {
            Console.WriteLine(alternativa.ToString());
        }
    }
}