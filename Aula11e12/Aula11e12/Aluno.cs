using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula11e12
{
    public class Aluno
    {
        //Caraterísticas (Propriedades) do aluno
        public string Numero { get; private set; }
        public string Nome { get; private set; }
        public string Curso { get; private set; }
        public bool Inscrito { get; set; } // set público poe estar fora dos parâmetros do construtor

        //Inicialização das propriedades do aluno
        public Aluno(string numero, string nome, string curso)
        {
            Numero = numero;
            Nome = nome;
            Curso = curso;
            Inscrito = false;
        }
    }
}
