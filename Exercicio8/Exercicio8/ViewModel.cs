namespace Exercicio8
{
    public class ViewModel
    { 
        public Grade Grade { get; private set; }

        public event MetodosSemParametros AlteracaoBasilhame;

        public void DefineGrade(Capacidades tipoGarrafa, int quantasGarrafas)
        {
            // inicializa a GRADE do Model
            Grade = new Grade(tipoGarrafa, quantasGarrafas);
        }

        public void AdicionaCerveja(Cerveja garrafa)
        {
            if(garrafa != null)
            {
                Grade.Adiciona(garrafa);

                if (AlteracaoBasilhame != null)
                {
                    AlteracaoBasilhame();
                }
            }
        }

        public Cerveja RemoveCerveja()
        {
            Cerveja cerv = Grade.RetiraCheia();
            if(cerv != null)
            {
                if (AlteracaoBasilhame != null)
                {
                    AlteracaoBasilhame();
                }
            }
            return cerv;
        }

        public Cerveja RemoveGarrafa()
        {
            Cerveja cerv = Grade.RetiraVazia();
            if (cerv != null)
            {
                if (AlteracaoBasilhame != null)
                {
                    AlteracaoBasilhame();
                }
            }
            return cerv;
        }
    }
}
