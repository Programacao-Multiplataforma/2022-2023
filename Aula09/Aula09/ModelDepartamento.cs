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
