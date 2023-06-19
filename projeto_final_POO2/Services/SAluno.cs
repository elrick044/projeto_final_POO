using Org.BouncyCastle.Asn1.Pkcs;

namespace projeto_final_POO2.controllers;

public class SAluno
{

    private readonly AlunoRepository _alunoRepository = new AlunoRepository();
    private readonly AlunoMateriaRepository _alunoMateriaRepository = new AlunoMateriaRepository();
    private readonly MateriaRepository _materiaRepository = new MateriaRepository();
    private static readonly ProvaRepository ProvaRepository = new ProvaRepository();
    private static readonly MateriaRepository MateriaRepository = new MateriaRepository();
    private static readonly QuestaoRepository QuestaoRepository = new QuestaoRepository();
    private static readonly AlternativaRepository AlternativaRepository = new AlternativaRepository();
    private static readonly SMateria ServiceSMateria = new SMateria();
    private static readonly SProva ServiceSProva = new SProva();

    public void Add()
    {
        Console.WriteLine("--== DIGITE OS DADOS DO ALUNO: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();

        Aluno aluno = new Aluno(null, nome, login, senha, new List<AlunoMateria>());

        _alunoRepository.Add(aluno);
    }

    public Aluno Login()
    {
        Console.WriteLine("--== LOGIN ==--");
        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();

        Aluno aluno = _alunoRepository.login(login, senha);

        return aluno;
    }

    public void  Register(Aluno aluno)
    {
        Console.WriteLine("--== MATERIAS ==--");
        
        ServiceSMateria.GetAll(null);

        Console.WriteLine("Id da Materia: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o Id da Materia: ");
        }

        Materia materia = MateriaRepository.GetById(id);

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
                AlunoMateria alunoMateria = new AlunoMateria(Convert.ToInt32(aluno.Id), Convert.ToInt32(materia.Id), 0);
                _alunoMateriaRepository.Add(alunoMateria);
            }
            else
            {
                Console.WriteLine("Chave inválida");
            }
        }
    }

    public List<Materia> GetMateriasAluno(Aluno aluno)
    {
        Console.WriteLine("--== MATERIAS ==--");

        List<AlunoMateria> alunosMaterias = _alunoMateriaRepository.getAllByIdAluno(Convert.ToInt32(aluno.Id));
        List<Materia> materias = new List<Materia>();

        foreach (var  alunoMateria in alunosMaterias)
        {
            materias.Add(_materiaRepository.GetById(alunoMateria.IdMateria));
        }

        return materias;
    }

    public void GetProvasAluno(Aluno aluno, bool dentroDoPrazo)
    {
        List < Materia > materias = GetMateriasAluno(aluno);
        
        foreach (var materia in materias)
        {
            ServiceSProva.GetByMaterias(materia, dentroDoPrazo);
        }
    }

    public void DoTest(Aluno aluno)
    {
        int acertos = 0;

        Console.WriteLine("--== PROVAS ==--");
        GetProvasAluno(aluno, true);

        Console.WriteLine("Id da Prova: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Entrada inválida. Digite um número válido para o Id da Prova: ");
        }

        Prova prova = ProvaRepository.GetById(id);

        List<Questao> questoes = QuestaoRepository.GetByProva(prova);

        foreach (var questao in questoes)
        {
            List<Alternativa> alternativas = AlternativaRepository.GetByQuestao(questao);
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
            int resposta;
            while (!int.TryParse(Console.ReadLine(), out resposta))
            {
                Console.WriteLine("Entrada inválida. Digite um número válido para a Resposta: ");
            }

            if (correta.Id == resposta)
            {
                acertos++;
            }
        }

        double nota = Convert.ToDouble(acertos) * 100 / questoes.Count;

        AlunoMateria alunoMateria = _alunoMateriaRepository.GetByIds(Convert.ToInt32(aluno.Id), prova.MateriaId);
        alunoMateria.Nota = nota * prova.Peso;
        _alunoMateriaRepository.Update(alunoMateria);
        
        Console.WriteLine(acertos + " / " + questoes.Count);
        Console.WriteLine("Nota: " + nota);
    }

    public void imprimirMaterias(Aluno aluno)
    {
        List<Materia> materias = GetMateriasAluno(aluno);
        
        foreach (var materia in materias)
        {
            Console.WriteLine(materia);   
        }
    }
}
