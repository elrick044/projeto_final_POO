namespace projeto_final_POO2.controllers;

public class SQuestao
{
    private readonly QuestaoRepository _rq = new QuestaoRepository();
    private readonly ProvaRepository _rp = new ProvaRepository();

    public void Add(Prova prova)
    {
        Console.WriteLine("--== DIGITE OS DADOS DA QUESTAO: ==--");
        Console.WriteLine("Título:");
        string titulo = Console.ReadLine();
       
        Questao questao = new Questao(null, titulo, Convert.ToInt32(prova.Id));

        _rq.Add(questao);
    }

    public void Update(Questao q, Prova p)
    {
        Console.WriteLine("--== DIGITE OS NOVOS DADOS DA QUESTAO: ==--");
        Console.WriteLine("Título:");
        string titulo = Console.ReadLine();
        
        Questao questao = new Questao(q.Id, titulo, Convert.ToInt32(p.Id));

        _rq.Update(Convert.ToInt32(questao.Id), questao);
    }

    public void Delete(Questao questao)
    {
        _rq.Delete(questao);
    }

    public Questao GetByID(int id)
    {
        Questao questao = _rq.GetById(id);

        Console.WriteLine(questao.ToString());

        return questao;
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
