namespace Aula10
{
    public interface IBateria
    {
        //Propriedades
        int Carga
        {
            get;
            set;
        }

        //Métodos
        void Carregar();
        void Descarregar();

        //Eventos
        event MetodosComInt CargaAlterada;
    }
}
