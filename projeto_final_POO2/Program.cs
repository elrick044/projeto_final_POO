using Newtonsoft.Json;
using projeto_final_POO2.controllers;

public class AplicativoProvas
{
    public static string ConvertToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    
    public static readonly SProfessor sp = new SProfessor();
    public static readonly SAluno sa = new SAluno();
    
    public static void Main(string[] args)
    {
        
            
            int sair = 0;
            bool loged = false;
    
            Professor professor = new Professor();
            Aluno aluno = new Aluno();
    
            while (sair != 1)
            {
                if (!loged)
                {
                    switch (MenuPessoa())
                    {
                        case 1:
                            switch (MenuSign())
                            {
                                case 1:
                                    sp.Add();
                                    break;
                                case 2:
                                    while (professor == null)
                                    {
                                        professor = sp.Login();
                                    }
    
                                    loged = true;
                                    break;
                                default:
                                    break;
                            }
    
                            break;
                        case 2:
                            switch (MenuSign())
                            {
                                case 1:
                                    sa.Add();
                                    break;
                                case 2:
                                    while (aluno == null)
                                    {
                                        aluno = sa.Login();
                                    }
    
                                    loged = true;
                                    break;
                                default:
                                    break;
                            }
    
                            break;
                        default:
                            sair = 1;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("LOGADO KRL");
                }
            }
            
    }

    public static int MenuPessoa()
    {
        Console.WriteLine("--== ESCOLHA SUA OPÇÃO ==--");
        Console.WriteLine("1 - PROFESSOR");
        Console.WriteLine("2 - ALUNO");
        Console.WriteLine("0 - SAIR");
        return Convert.ToInt32(Console.ReadLine());
    }

    public static int MenuSign()
    {
        Console.WriteLine("--== ESCOLHA SUA OPÇÃO: ==--");
        Console.WriteLine("1 - CADASTRO");
        Console.WriteLine("2 - LOGIN");
        return Convert.ToInt32(Console.ReadLine());
    }
}