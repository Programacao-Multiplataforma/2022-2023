using Exercicio4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    public class ViewModel
    {
        public Aluno Dados { get; private set; }

        public event MetodosSemParametros LeituraTerminada;

        public event MetodosComAlunos AlteracaoEfetuada;

        public ViewModel()
        {
            Dados = new Aluno();
        }

        public void LerFicheiro(string fich)
        {
            //StreamReader sr = new StreamReader(fich);
            StreamReader sr = File.OpenText(fich);
            Dados.Numero = sr.ReadLine();
            Dados.Nome = sr.ReadLine();
            Dados.Curso = sr.ReadLine();
            sr.Close();

            // lançar notificação de leitura terminada
            if(LeituraTerminada != null)
            {
                LeituraTerminada();
            }
        }

        public void ModificaDados(Aluno aluno)
        {
            Dados = aluno;

            // lançar notificação de leitura terminada
            if (AlteracaoEfetuada != null)
            {
                AlteracaoEfetuada(aluno);
            }
        }
    }
}
