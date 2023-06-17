using Org.BouncyCastle.Asn1.Pkcs;

namespace projeto_final_POO2.controllers;

public class SAluno
{

    private readonly AlunoRepository _ra = new AlunoRepository();
    private static readonly ProvaRepository Rp = new ProvaRepository();
    private static readonly MateriaRepository Rm = new MateriaRepository();
    private static readonly QuestaoRepository Rq = new QuestaoRepository();
    private static readonly AlternativaRepository Ra = new AlternativaRepository();
    private static readonly SMateria Sm = new SMateria();
    private static readonly SProva Sp = new SProva();

    public void Add(){
        Console.WriteLine("--== DIGITE OS DADOS DO ALUNO: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();
      
        Aluno aluno = new Aluno(null, nome, login, senha, null);

        _ra.Add(aluno);
    }

    public Aluno Login(){
        Console.WriteLine("--== LOGIN ==--");
        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();

        Aluno aluno = _ra.login(login, senha);

        return aluno;
    }

    public void Register(Aluno aluno)
    {
        Console.WriteLine("--== MATERIAS ==--");
        Sm.GetAll();
        
        Console.WriteLine("Id da Materia: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Materia materia = Rm.GetById(id);

        string chave = null;
        
        while (chave != materia.Chave)
        {
            Console.WriteLine("Chave (Se não souber a chave digite NAO para voltar para o menu): ");
            chave = Console.ReadLine();

            if (chave == "NAO")
            {
                break;
            }

            if (chave == materia.Chave)
            {
              materia.Alunos.Add(aluno);
              aluno.Materias.Add(materia);
            }
        }
    }

    public void GetMateriasAluno(Aluno aluno)
    {
        Console.WriteLine("--== MATERIAS ==--");
        
        foreach (var materia in aluno.Materias)
        {
            Console.WriteLine(materia.ToString());
        }
    }
    
    public void GetProvasAluno(Aluno aluno)
    {
        foreach (var materia in aluno.Materias)
        {
            Sp.GetByMaterias(materia);
        }
    }

    public void DoTest(Aluno aluno)
    {
        int acertos = 0;

        Console.WriteLine("--== PROVAS ==--");
        GetProvasAluno(aluno);
        
        Console.WriteLine("Id da Prova: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Prova prova = Rp.GetById(id);

        List<Questao> questoes = Rq.GetByProva(prova);

        foreach (var questao in questoes)
        {
            List<Alternativa> alternativas = Ra.GetByQuestao(questao);
            Console.WriteLine(questao.Titulo);

            Alternativa correta = null;
            
            foreach (var alternativa in alternativas)
            {
                Console.WriteLine(alternativa.Id + " - " + alternativa.Texto);
                if (alternativa.Correta)
                {
                    correta = alternativa;
                }
            }
            
            Console.WriteLine("Resposta: ");
            if (correta.Id == Convert.ToInt32(Console.ReadLine()))
            {
                acertos++;
            }
        }
        
        Console.WriteLine(acertos + " / " + questoes.Count);
        Console.WriteLine("Nota: " + Convert.ToDouble(acertos) * 100 / questoes.Count);
    }
    
    
}