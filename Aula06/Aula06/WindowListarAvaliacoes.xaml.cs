using System.Windows;

namespace Aula06
{
    /// <summary>
    /// Interaction logic for WindowListarAvaliacoes.xaml
    /// </summary>
    public partial class WindowListarAvaliacoes : Window
    {
        private App app;
        public WindowListarAvaliacoes()
        {
            InitializeComponent();

            app = App.Current as App;

            //Subscrição de um método no evento do Model
            app.Model_Classificacoes.NotaInserida += Model_Classificacoes_NotaInserida;
        }

        private void Model_Classificacoes_NotaInserida(int valor)
        {
            if (valor >= 10)
                lvClassificacoes.Items.Add("Aprovado (" + valor + ")");
            else
                lvClassificacoes.Items.Add("Reprovado (" + valor + ")");
        }
    }
}
