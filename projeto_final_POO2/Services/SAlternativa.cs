using System;
using System.Collections.Generic;

namespace projeto_final_POO2.controllers
{
    public class SAlternativa
    {
        private readonly AlternativaRepository _ra = new AlternativaRepository();
        private readonly QuestaoRepository _rq = new QuestaoRepository();

        public void Add()
        {
            Console.WriteLine("--== DIGITE OS DADOS DA ALTERNATIVA: ==--");

            Console.WriteLine("Texto:");
            string texto = Console.ReadLine();

            bool correta = false;
            bool corretaValida = false;
            while (!corretaValida)
            {
                Console.WriteLine("Correta (true/false):");
                string corretaStr = Console.ReadLine();

                if (bool.TryParse(corretaStr, out correta))
                {
                    corretaValida = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite 'true' ou 'false'.");
                }
            }

            int id = 0;
            bool idValido = false;
            while (!idValido)
            {
                Console.WriteLine("Id da Questão:");
                string idStr = Console.ReadLine();

                if (int.TryParse(idStr, out id))
                {
                    idValido = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                }
            }

            Questao questao = _rq.GetById(id);
            if (questao != null)
            {
                Alternativa alternativa = new Alternativa(null, texto, correta, Convert.ToInt32(questao.Id));
                _ra.Add(alternativa);
            }
            else
            {
                Console.WriteLine("Questão não encontrada!");
            }
        }

        public void Update()
        {
            Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER ALTERADA:");
            int id = 0;
            bool idValido = false;
            while (!idValido)
            {
                string idStr = Console.ReadLine();
                if (int.TryParse(idStr, out id))
                {
                    idValido = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                }
            }

            Console.WriteLine("--== DIGITE OS NOVOS DADOS DA ALTERNATIVA: ==--");
            Console.WriteLine("Texto:");
            string texto = Console.ReadLine();

            bool correta = false;
            bool corretaValida = false;
            while (!corretaValida)
            {
                Console.WriteLine("Correta (true/false):");
                string corretaStr = Console.ReadLine();

                if (bool.TryParse(corretaStr, out correta))
                {
                    corretaValida = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite 'true' ou 'false'.");
                }
            }

            int idq = 0;
            bool idqValido = false;
            while (!idqValido)
            {
                Console.WriteLine("Id da Prova:");
                string idqStr = Console.ReadLine();

                if (int.TryParse(idqStr, out idq))
                {
                    idqValido = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                }
            }

            Questao questao = _rq.GetById(idq);
            if (questao != null)
            {
                Alternativa alternativa = new Alternativa(id, texto, correta, Convert.ToInt32(questao.Id));
                _ra.Update(alternativa);
            }
            else
            {
                Console.WriteLine("Questão não encontrada!");
            }
        }

        public void Delete()
        {
            Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER DELETADA:");
            int id = 0;
            bool idValido = false;
            while (!idValido)
            {
                string idStr = Console.ReadLine();
                if (int.TryParse(idStr, out id))
                {
                    idValido = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                }
            }

            Alternativa alternativa = _ra.GetById(id);
            if (alternativa != null)
            {
                _ra.Delete(alternativa);
            }
            else
            {
                Console.WriteLine("Alternativa não encontrada!");
            }
        }

        public void GetByID()
        {
            Console.WriteLine("DIGITE O ID DA ALTERNATIVA A SER IMPRESSA:");
            int id = 0;
            bool idValido = false;
            while (!idValido)
            {
                string idStr = Console.ReadLine();
                if (int.TryParse(idStr, out id))
                {
                    idValido = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                }
            }

            Alternativa alternativa = _ra.GetById(id);
            if (alternativa != null)
            {
                Console.WriteLine(alternativa.ToString());
            }
            else
            {
                Console.WriteLine("Alternativa não encontrada!");
            }
        }

        public void GetAll()
        {
            List<Alternativa> alternativas = _ra.GetAll();

            foreach (var alternativa in alternativas)
            {
                Console.WriteLine(alternativa.ToString());
            }
        }
    }
}
