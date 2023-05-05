using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ViewModel
    {
        // atributos (propriedades) que caracterizam o Model
        public string Texto { get; private set; }

        
        public void CarregaFicheiro(string fich)
        {
            Texto = File.ReadAllText(fich); // método simplificado de ler o ficheiro
        }

        // mensagens (métodos) da questão 1
        public int NumeroParagrafos { 
            get { 
                return Texto.Split('\n').Length; 
            } 
        }

        public int NumeroPalavras
        {
            get
            {
                char[] separadores = { '\n', ' ', ',', '.', '!', '?', '\t', '(', ')' }; // outros separadores podem ser adicionados
                return Texto.Split(separadores, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }

        public int NumeroCaracteres // incluindo caracteres brancos
        {
            get
            {
                return Texto.Length;
            }
        }

        public int NumeroOcorrencias(string palavra)
        {
            char[] separadores = { '\n', ' ', ',', '.', '!', '?', '\t', '(', ')' }; // outros separadores podem ser adicionados
            string[] palavras = Texto.Split(separadores, StringSplitOptions.RemoveEmptyEntries);
            
            return palavras.Count(x => x.Equals(palavra));
        }

    }
}
