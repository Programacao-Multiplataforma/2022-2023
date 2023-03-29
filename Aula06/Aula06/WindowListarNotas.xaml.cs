using System.Windows;

namespace Aula06
{
    /// <summary>
    /// Interaction logic for WindowListarNotas.xaml
    /// </summary>
    public partial class WindowListarNotas : Window
    {
        private App app;
        public WindowListarNotas()
        {
            InitializeComponent();

            app = App.Current as App;

            //Subscrição de um método no evento do Model
            app.Model_Classificacoes.NotaInserida += Model_Classificacoes_NotaInserida;
        }

        private void Model_Classificacoes_NotaInserida(int valor)
        {
            lbNotas.Items.Add(valor + " valores");
        }
    }
}
