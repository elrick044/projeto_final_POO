public class AlternativaRepository : Repository<Alternativa>, IAlternativaRepository
{
    public ApplicationDbContext Context = new ApplicationDbContext();

    public List<Alternativa> GetByQuestao(Questao questao)
    {
        return Context.Set<Alternativa>().Where(u => u.QuestaoId == questao.Id).ToList();
    }
}