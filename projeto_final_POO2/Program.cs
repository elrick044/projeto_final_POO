using System;
using System.Data.SqlTypes;
using Newtonsoft.Json;
using projeto_final_POO2.controllers;
using projeto_final_POO2.menu;

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
                switch (Menu.MenuPessoa())
                {
                    case 1:
                        switch (Menu.MenuSign())
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
                        switch (Menu.MenuSign())
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
                        char op = Menu.MenuProfessor();

                        if (op == '+')
                        {
                            serviceMateria.Add(professor);
                        }
                        else if ((int)Char.GetNumericValue(op) > 0)
                        {
                            Materia materia = serviceMateria.GetByID((int)Char.GetNumericValue(op));

                            op = Menu.MenuMateria();

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
                                    op = Menu.MenuProva();

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
                                            op = Menu.MenuQuestao();

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
                                                    op = Menu.MenuAlternativa();

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

                        switch (Menu.MenuAluno())
                        {
                            case 1:
                                serviceAluno.Register(aluno);
                                break;
                            case 2:
                                serviceAluno.imprimirMaterias(aluno);
                                break;
                            case 3:
                                serviceAluno.GetProvasAluno(aluno, false);
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
}