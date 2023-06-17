namespace projeto_final_POO2.controllers;

public class SQuestao
{
    private readonly QuestaoRepository _rq = new QuestaoRepository();
    private readonly ProvaRepository _rp = new ProvaRepository();
    
    public void Add(){
        Console.WriteLine("--== DIGITE OS DADOS DA QUESTAO: ==--");
        Console.WriteLine("Título:");
        string titulo = Console.ReadLine();
        
        Console.WriteLine("Id da Prova: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Prova prova = _rp.GetById(id);

        Questao questao = new Questao(null, titulo, Convert.ToInt32(prova.Id));

        _rq.Add(questao);
    }

    public void Update()
    {
        Console.WriteLine("DIGITE O ID DA QUESTAO A SER ALTERADA: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("--== DIGITE OS NOVOS DADOS DA QUESTAO: ==--");
        Console.WriteLine("Título:");
        string titulo = Console.ReadLine();
        
        Console.WriteLine("Id da Prova: ");
        int idp = Convert.ToInt32(Console.ReadLine());

        Prova prova = _rp.GetById(idp);

        Questao questao = new Questao(id, titulo, Convert.ToInt32(prova.Id));
        
        _rq.Update(questao);
    }

    public void Delete()
    {
        Console.WriteLine("DIGITE O ID DA PROVA A SER DELETADA: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Prova prova = _rp.GetById(id);

        _rp.Delete(prova);
    }

    public void GetByID()
    {
        Console.WriteLine("DIGITE O ID DA QUESTAO A SER IMPRESSA: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Questao questao = _rq.GetById(id);

        Console.WriteLine(questao.ToString());
    }

    public void GetAll()
    {
        List<Questao> questoes = _rq.GetAll();

        foreach (var questao in questoes)
        {
            Console.WriteLine(questao.ToString());
        }
    }
}