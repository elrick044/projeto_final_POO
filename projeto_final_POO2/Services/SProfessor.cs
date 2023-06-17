using System;

namespace projeto_final_POO2.controllers
{
    public class SProfessor
    {

        private readonly ProfessorRepository _rp = new ProfessorRepository();

        public void Add()
        {
            Console.WriteLine("--== DIGITE OS DADOS DO PROFESSOR: ==--");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();

            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome inválido! Digite novamente:");
                nome = Console.ReadLine();
            }

            Console.WriteLine("Login: ");
            string login = Console.ReadLine();

            while (string.IsNullOrEmpty(login))
            {
                Console.WriteLine("Login inválido! Digite novamente:");
                login = Console.ReadLine();
            }

            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();

            while (string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("Senha inválida! Digite novamente:");
                senha = Console.ReadLine();
            }

            Professor professor = new Professor(null, nome, login, senha);

            _rp.Add(professor);
        }

        public Professor Login()
        {
            Professor professor = new Professor();
            Console.WriteLine("--== LOGIN ==--");
            Console.WriteLine("Login: ");
            string login = Console.ReadLine();

            while (string.IsNullOrEmpty(login))
            {
                Console.WriteLine("Login inválido! Digite novamente:");
                login = Console.ReadLine();
            }

            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();

            while (string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("Senha inválida! Digite novamente:");
                senha = Console.ReadLine();
            }

            professor = _rp.login(login, senha);
            Console.WriteLine(professor.Id);
            return professor;
        }
    }
}
