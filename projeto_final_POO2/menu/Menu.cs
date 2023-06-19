using projeto_final_POO2.controllers;

namespace projeto_final_POO2.menu;

public class Menu
{
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
        SMateria serviceMateria = new SMateria();
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
        SProva serviceProva = new SProva();
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
        SQuestao serviceQuestao = new SQuestao();
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
        SAlternativa serviceAlternativa = new SAlternativa();
        
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