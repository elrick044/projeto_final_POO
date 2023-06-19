using System;
using System.Collections.Generic;

namespace projeto_final_POO2.controllers
{
    public class SAlternativa
    {
        private readonly AlternativaRepository _ra = new AlternativaRepository();
        private readonly QuestaoRepository _rq = new QuestaoRepository();

        public void Add(Questao questao)
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

        public void Update(Alternativa a, Questao questao)
        {
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
            
            if (questao != null)
            {
                Alternativa alternativa = new Alternativa(a.Id, texto, correta, Convert.ToInt32(questao.Id));
                _ra.Update(Convert.ToInt32(alternativa.Id),alternativa);
            }
            else
            {
                Console.WriteLine("Questão não encontrada!");
            }
        }

        public void Delete(Alternativa alternativa)
        {
            _ra.Delete(alternativa);
        }

        public Alternativa GetByID(int id)
        {
            Alternativa alternativa = _ra.GetById(id);
            if (alternativa != null)
            {
                Console.WriteLine(alternativa.ToString());
            }
            else
            {
                Console.WriteLine("Alternativa não encontrada!");
            }

            return alternativa;
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