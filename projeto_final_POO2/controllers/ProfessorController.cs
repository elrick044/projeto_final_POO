﻿namespace projeto_final_POO2.controllers;

public class SProfessor
{
    
    private readonly ProfessorRepository _rp = new ProfessorRepository();

    public void Add(){
        Console.WriteLine("--== DIGITE OS DADOS DO PROFESSOR: ==--");
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();
      
        Professor professor = new Professor(null, nome, login, senha);

        _rp.Add(professor);
    }

    public Professor Login(){
        Console.WriteLine("--== LOGIN ==--");
        Console.WriteLine("Login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Senha: ");
        string senha = Console.ReadLine();

        Professor professor = _rp.login(login, senha);
        return professor;
    }
}