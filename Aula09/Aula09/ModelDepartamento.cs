using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula09
{
    public class ModelDepartamento
    {
        public string Designacao { get; private set; }
        public string Docentes { get; private set; }

        public ModelDepartamento(string designacao, string nDocentes)
        {
            Designacao = designacao;
            Docentes = nDocentes;
        }
    }
}
