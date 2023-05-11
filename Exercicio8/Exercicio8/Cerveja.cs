namespace Exercicio8
{
    public class Cerveja : IGarrafa
    {
        // atributos
        private Capacidades _capacidade;
        private bool _cheia;

        // propriedades
        public Capacidades Capacidade { get { return _capacidade; } set { _capacidade = value; } }

        public bool Cheia { get { return _cheia; } }

        // metodos
        public Cerveja(Capacidades capacidade, bool cheia)
        {
            _capacidade = capacidade;
            _cheia = cheia;
        }
    }
}
