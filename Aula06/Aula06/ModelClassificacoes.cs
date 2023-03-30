using System;
using System.Collections.Generic;

namespace Aula06
{
    public class ModelClassificacoes
    {
        //Armazenamento dos dados
        public List<string> ListaNotas { get; private set; }

        //PASSO 1: Criar delegate // movido para o ficheiro Delegates.cs
        //public delegate void MetodosComInt(int valor);

        //PASSO 2: Criar event
        public event MetodosComInt NotaInserida;

        public ModelClassificacoes()
        {
            ListaNotas = new List<string>();
        }

        public void Inserir(string nota)
        {
            ListaNotas.Add(nota);

            int valor = Convert.ToInt16(Math.Round(Convert.ToDouble(nota), MidpointRounding.AwayFromZero));

            //PASSO 3: Lançar event
            if (NotaInserida != null)
                NotaInserida(valor);
        }
    }
}
