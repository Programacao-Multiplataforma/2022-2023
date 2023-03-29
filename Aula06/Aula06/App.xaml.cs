using System.Windows;

namespace Aula06
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Views
        public WindowListarNotas View_ListarNotas { get; private set; }
        public WindowListarAvaliacoes View_ListarAvaliacoes { get; private set; }

        //Models
        public ModelClassificacoes Model_Classificacoes { get; private set; }

        public App()
        {
            //Models
            Model_Classificacoes = new ModelClassificacoes();

            //Views
            View_ListarNotas = new WindowListarNotas();
            View_ListarAvaliacoes = new WindowListarAvaliacoes();
        }
    }
}
