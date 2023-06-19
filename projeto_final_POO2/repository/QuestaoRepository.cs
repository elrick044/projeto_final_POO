public class QuestaoRepository : Repository<Questao>, IQuestaoRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Questao> GetByProva(Prova prova)
    {
        return Context.Set<Questao>().Where(u => u.ProvaId == prova.Id).ToList();
    }
}