using System;
using System.Data.SqlTypes;
using Newtonsoft.Json;
using projeto_final_POO2.controllers;

public class AplicativoProvas
{
    public static string ConvertToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static readonly SProfessor serviceProfessor = new SProfessor();
    public static readonly SAluno serviceAluno = new SAluno();
    public static readonly SMateria serviceMateria = new SMateria();
    public static readonly SProva serviceProva = new SProva();
    public static readonly SQuestao serviceQuestao = new SQuestao();
    public static readonly SAlternativa serviceAlternativa = new SAlternativa();

    public static void Main(string[] args)
    {
        int sair = 0;
        bool loged = false;

        Professor professor = null;
        Aluno aluno = null;

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
                                serviceProfessor.Add();
                                break;
                            case 2:
                                while (professor == null)
                                {
                                    professor = serviceProfessor.Login();
                                    Console.WriteLine(professor.Nome);
                                }

                                loged = true;
                                break;
                            default:
                                sair = 1;
                                break;
                        }

                        break;
                    case 2:
                        switch (MenuSign())
                        {
                            case 1:
                                serviceAluno.Add();
                                break;
                            case 2:
                                while (aluno == null)
                                {
                                    aluno = serviceAluno.Login();
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
                int fim = 0;

                if (professor != null)
                {
                    while (loged)
                    {
                        char op = MenuProfessor();

                        if (op == '+')
                        {
                            serviceMateria.Add(professor);
                        }
                        else if ((int)Char.GetNumericValue(op) > 0)
                        {
                            Materia materia = serviceMateria.GetByID((int)Char.GetNumericValue(op));

                            op = MenuMateria();

                            if (op == '+')
                            {
                                serviceProva.Add(materia);
                            }
                            else if (op == '-')
                            {
                                serviceMateria.Delete(materia);
                            }
                            else if (op == 'u')
                            {
                                serviceMateria.Update(materia);
                            }
                            else if ((int)Char.GetNumericValue(op) > 0)
                            {
                                Prova prova = serviceProva.GetByID((int)Char.GetNumericValue(op));

                                while (true)
                                {
                                    op = MenuProva();

                                    if (op == '+')
                                    {
                                        serviceQuestao.Add(prova);
                                    }
                                    else if (op == '-')
                                    {
                                        serviceProva.Delete(prova);
                                    }
                                    else if (op == 'u')
                                    {
                                        serviceProva.Update(prova);
                                    }
                                    else if ((int)Char.GetNumericValue(op) > 0)
                                    {
                                        Questao questao = serviceQuestao.GetByID((int)Char.GetNumericValue(op));

                                        while (true)
                                        {
                                            op = MenuQuestao();

                                            if (op == '+')
                                            {
                                                serviceAlternativa.Add(questao);
                                            }
                                            else if (op == '-')
                                            {
                                                serviceQuestao.Delete(questao);
                                            }
                                            else if (op == 'u')
                                            {
                                                serviceQuestao.Update(questao, prova);
                                            }
                                            else if ((int)Char.GetNumericValue(op) > 0)
                                            {
                                                Alternativa alternativa = serviceAlternativa.GetByID((int)Char.GetNumericValue(op));

                                                while (true)
                                                {
                                                    op = MenuAlternativa();

                                                    if (op == '-')
                                                    {
                                                        serviceAlternativa.Delete(alternativa);
                                                    }
                                                    else if (op == 'u')
                                                    {
                                                        serviceAlternativa.Update(alternativa, questao);
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }else
                            {
                                break;
                            }
                        }
                        else
                        {
                            loged = false;
                            professor = null;
                            break;
                        }
                    }
                }

                else if (aluno != null)
                {
                    while (fim != 1)
                    {
                        int brk = 0;

                        switch (MenuAluno())
                        {
                            case 1:
                                serviceAluno.Register(aluno);
                                break;
                            case 2:
                                serviceAluno.imprimirMaterias(aluno);
                                break;
                            case 3:
                                serviceAluno.GetProvasAluno(aluno);
                                break;
                            case 4:
                                serviceAluno.DoTest(aluno);
                                break;
                            default:
                                sair = 1;
                                loged = false;
                                aluno = null;
                                break;
                        }
                    }
                }
            }
        }
    }

    public static int MenuPessoa()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("--== ESCOLHA SUA OPÇÃO ==--");
            Console.WriteLine("1 - PROFESSOR");
            Console.WriteLine("2 - ALUNO");
            Console.WriteLine("0 - SAIR");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 0 && opcao <= 2)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Digite um número válido.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Digite um número válido.");
            }
        }

        return opcao;
    }

    public static int MenuSign()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("--== ESCOLHA SUA OPÇÃO: ==--");
            Console.WriteLine("1 - CADASTRO");
            Console.WriteLine("2 - LOGIN");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 1 && opcao <= 2)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Digite um número válido.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Digite um número válido.");
            }
        }

        return opcao;
    }

    public static char MenuProfessor()
    {
        char opcao = '0';
        bool entradaValida = false;

        
        Console.WriteLine("-=: Menu do professor :=-");
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("+ - Adicionar materia");
            serviceMateria.GetAll(null);
            Console.WriteLine("0 - Logout");
            opcao = Convert.ToChar(Console.ReadLine());

            
        return opcao;
    }

    public static int MenuAluno()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("-=: Menu aluno :=-");
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Entrar em Materia");
            Console.WriteLine("2 - Ver Materias");
            Console.WriteLine("3 - Ver Provas");
            Console.WriteLine("4 - Fazer Prova");
            Console.WriteLine("0 - Logout");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 0 && opcao <= 4)
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Digite um número válido.");
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Digite um número válido.");
            }
        }

        return opcao;
    }

    public static char MenuMateria()
    {
        char opcao = '0';
        bool entradaValida = false;
        
        Console.WriteLine("-=: Menu matéria :=-");
        Console.WriteLine("-=: Digite a opção desejada :=-");
        Console.WriteLine("u - Atualizar");
        Console.WriteLine("- - Excluir");
        Console.WriteLine("+ - Adicionar prova");
        serviceProva.GetAll();
        Console.WriteLine("0 - Sair");
        opcao = Convert.ToChar(Console.ReadLine());

        return opcao;
    }

    public static char MenuProva()
    {
        char opcao = '0';
        bool entradaValida = false;

        Console.WriteLine("-=: Menu prova :=-");
        Console.WriteLine("-=: Digite a opção desejada :=-");
        Console.WriteLine("u - Atualizar");
        Console.WriteLine("- - Excluir");
        Console.WriteLine("+ - Adicionar questao");
        serviceQuestao.GetAll();
        Console.WriteLine("0 - Sair");
            
        
        opcao = Convert.ToChar(Console.ReadLine());

        
        return opcao;
    }

    public static char MenuQuestao()
    {
        char opcao = '0';
        bool entradaValida = false;
        
        Console.WriteLine("-=: Menu questão :=-");
        Console.WriteLine("-=: Digite a opção desejada :=-");
        Console.WriteLine("u - Atualizar");
        Console.WriteLine("- - Excluir");
        Console.WriteLine("+ - Adicionar alternativa");
        serviceAlternativa.GetAll();
        Console.WriteLine("0 - Sair");

        opcao = Convert.ToChar(Console.ReadLine());
        
        return opcao;
    }

    public static char MenuAlternativa()
    {
        char opcao = '0';
        bool entradaValida = false;
        
        Console.WriteLine("-=: Menu alternativa :=-");
        Console.WriteLine("-=: Digite a opção desejada :=-");
        Console.WriteLine("u - Atualizar");
        Console.WriteLine("- - Excluir");
        Console.WriteLine("0 - Sair");

        opcao = Convert.ToChar(Console.ReadLine());

        return opcao;
    }
}