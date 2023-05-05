using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula09
{
    public class ModelEscola : IEnumerable
    {
        //Acesso público à estrutura de dados do Model (Estado da aplicação)
        //public List<ModelDepartamento> Departamentos { get; private set; }
        //Acesso privado à estrutura de dados do Model (Estado da aplicação)
        private List<ModelDepartamento> Departamentos;
        public string Escola { get; private set; }

        public event MetodosSemParametros TerminadaInicializacao;

        public ModelEscola()
        {
            //Inicialização da estrutura de dados do Model (Estado da aplicação)
            Departamentos = new List<ModelDepartamento>();
        }

        public void Inicializar()
        {
            //Simulação obtenção de dados de uma fonte de dados
            Departamentos.Add(new ModelDepartamento("Engenharias", "150"));
            Departamentos.Add(new ModelDepartamento("Física", "30"));
            Departamentos.Add(new ModelDepartamento("Matemática", "60"));

            Escola = "Ciências e Tecnologia";

            if (TerminadaInicializacao != null)
                TerminadaInicializacao();
        }

        //Implementação do enumerador/iterador
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Departamentos.Count; i++)
                yield return Departamentos[i];
        }

        //Métodos de consulta de dados do Model
        public string ObterDocentes(int index)
        {
            //Devolve número de docentes do departamento da posição index
            return Departamentos[index].Docentes;
        }
    }
}
