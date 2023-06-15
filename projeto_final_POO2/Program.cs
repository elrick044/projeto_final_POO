using Newtonsoft.Json;

public class AplicativoProvas
{
    public static string ConvertToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static void Main()
    {
        
    }

}