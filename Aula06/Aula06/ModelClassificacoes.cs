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

        //PASSO 2: Criar notificações (eventos)
        public event MetodosComInt NotaInserida;  // nova nota inserida

        public event MetodosComString NotaComValorErrado; // nota inserida com valor errado

        public ModelClassificacoes()
        {
            ListaNotas = new List<string>();
        }

        public void Inserir(string nota)
        {
            Double notaInserida;

            if(Double.TryParse(nota, out notaInserida) == true)
            {
                int valor = Convert.ToInt16(Math.Round(notaInserida, MidpointRounding.AwayFromZero));

                if (valor >= 0 && valor <= 20)
                {
                    ListaNotas.Add(nota);

                    //PASSO 3: Lançar evento
                    if (NotaInserida != null)
                        NotaInserida(valor);
                }
                else // funcionalidade extra - validação dos valores inseridos
                {
                    if (NotaComValorErrado != null)
                        NotaComValorErrado("O valor na nota tem de ser entre 0 e 20");

                }
            }
            else // funcionalidade extra - validação dos valores inseridos
            {
                if (NotaComValorErrado != null)
                    NotaComValorErrado("A nota tem de ter um valor numérico entre 0 e 20");
            }
        }
    }
}
