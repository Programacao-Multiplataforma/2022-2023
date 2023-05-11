namespace Aula10
{
    public class ModelBateria : IBateria
    {
        //public int Carga { get; set; } = 0;

        // este código substitui o anterior para poder incluir a notificação de alteração após o uso do SET
        public int _carga = 0;

        public int Carga
        {
            get { return _carga; }
            set
            {
                _carga = value;

                if (CargaAlterada != null)
                    CargaAlterada(_carga);
            }
        }

        public event MetodosComInt CargaAlterada;

        public void Carregar()
        {
            if (Carga < 100)
            {
                Carga += 10; // assume-se incrementos de 10

                if (CargaAlterada != null)
                    CargaAlterada(Carga);
            }
            else
                throw new OperacaoInvalidaException("Foi atingido o limite máximo de carga!");
        }

        public void Descarregar()
        {
            if (Carga > 0)
            {
                Carga -= 10; // assume-se decrementos de 10

                if (CargaAlterada != null)
                    CargaAlterada(Carga);
            }
            else
                throw new OperacaoInvalidaException("Foi atingido o limite mínimo de carga!");
        }
    }
}
