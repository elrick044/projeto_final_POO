using Newtonsoft.Json;

public class AplicativoProvas
{
    public static string ConvertToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    
    public static void Main(string[] args)
    {
        using (var context = new ApplicationDbContext())
        {
            Repository<Professor> repository = new Repository<Professor>(context);

            //Professor a = new Professor(1, "Odair", "odair@gmail.com", "123456");
            //repository.Add(a);
            List <Professor> professores = repository.GetAll();

            foreach (var professor in professores)
            {
                Console.WriteLine(professor.Nome);
            }
        }
    }

}