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

    public static readonly SProfessor Sp = new SProfessor();
    public static readonly SAluno Sa = new SAluno();
    public static readonly SMateria Sm = new SMateria();
    public static readonly SProva Spr = new SProva();
    public static readonly SQuestao Sq = new SQuestao();
    public static readonly SAlternativa Sal = new SAlternativa();

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
                                Sp.Add();
                                break;
                            case 2:
                                while (professor == null)
                                {
                                    professor = Sp.Login();
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
                                Sa.Add();
                                break;
                            case 2:
                                while (aluno == null)
                                {
                                    aluno = Sa.Login();
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
                    while (fim != 1)
                    {
                        int brk = 0;

                        switch (MenuProfessor())
                        {
                            case 1: //Materia
                                while (brk != 1)
                                {
                                    switch (MenuMateria())
                                    {
                                        case 1:
                                            Sm.Add(professor);
                                            break;
                                        case 2:
                                            Sm.Update(professor);
                                            break;
                                        case 3:
                                            Sm.Delete();
                                            break;
                                        case 4:
                                            Sm.GetByID();
                                            break;
                                        case 5:
                                            Sm.GetAll();
                                            break;
                                        default:
                                            brk = 1;
                                            break;
                                    }
                                }

                                break;
                            case 2: //Prova
                                while (brk != 1)
                                {
                                    switch (MenuProva())
                                    {
                                        case 1:
                                            Spr.Add();
                                            break;
                                        case 2:
                                            Spr.Update();
                                            break;
                                        case 3:
                                            Spr.Delete();
                                            break;
                                        case 4:
                                            Spr.GetByID();
                                            break;
                                        case 5:
                                            Spr.GetAll();
                                            break;
                                        default:
                                            brk = 1;
                                            break;
                                    }
                                }

                                break;
                            case 3: //Questao
                                while (brk != 1)
                                {
                                    switch (MenuQuestao())
                                    {
                                        case 1:
                                            Sq.Add();
                                            break;
                                        case 2:
                                            Sq.Update();
                                            break;
                                        case 3:
                                            Sq.Delete();
                                            break;
                                        case 4:
                                            Sq.GetByID();
                                            break;
                                        case 5:
                                            Sq.GetAll();
                                            break;
                                        default:
                                            brk = 1;
                                            break;
                                    }
                                }

                                break;
                            case 4: //Alternativa
                                while (brk != 1)
                                {
                                    switch (MenuAlternativa())
                                    {
                                        case 1:
                                            Sal.Add();
                                            break;
                                        case 2:
                                            Sal.Update();
                                            break;
                                        case 3:
                                            Sal.Delete();
                                            break;
                                        case 4:
                                            Sal.GetByID();
                                            break;
                                        case 5:
                                            Sal.GetAll();
                                            break;
                                        default:
                                            brk = 1;
                                            break;
                                    }
                                }

                                break;
                            default:
                                loged = false;
                                professor = null;
                                fim = 1;
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
                                Sa.Register(aluno);
                                break;
                            case 2:
                                Sa.GetMateriasAluno(aluno);
                                break;
                            case 3:
                                Sa.GetProvasAluno(aluno);
                                break;
                            case 4: 
                                Sa.DoTest(aluno);
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

    public static int MenuProfessor()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Materia");
            Console.WriteLine("2 - Prova");
            Console.WriteLine("3 - Questao");
            Console.WriteLine("4 - Alternativas");
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
    
    public static int MenuAluno()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
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

    public static int MenuMateria()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Atualizar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Obter Por ID");
            Console.WriteLine("5 - Obter Todos");
            Console.WriteLine("0 - Sair");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 0 && opcao <= 5)
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
    
    public static int MenuProva()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Atualizar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Obter Por ID");
            Console.WriteLine("5 - Obter Todos");
            Console.WriteLine("0 - Sair");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 0 && opcao <= 5)
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

    public static int MenuQuestao()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Atualizar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Obter Por ID");
            Console.WriteLine("5 - Obter Todos");
            Console.WriteLine("0 - Sair");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 0 && opcao <= 5)
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

    public static int MenuAlternativa()
    {
        int opcao = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine("-=: Digite a opção desejada :=-");
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Atualizar");
            Console.WriteLine("3 - Excluir");
            Console.WriteLine("4 - Obter Por ID");
            Console.WriteLine("5 - Obter Todos");
            Console.WriteLine("0 - Sair");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                if (opcao >= 0 && opcao <= 5)
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
}
