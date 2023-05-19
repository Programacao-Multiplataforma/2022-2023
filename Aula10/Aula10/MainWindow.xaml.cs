using System.Windows;

namespace Aula10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variável com apontador para App (Camada de Interligação)
        private App _app;

        public MainWindow()
        {
            InitializeComponent();

            //Obtenção de apontador para App (Camada de Interligação)
            _app = App.Current as App;

            //Subscrição de método da View em Event do Model (Interligação Model->View)
            _app.M_Bateria.CargaAlterada += M_Bateria_CargaAlterada;
        }

        private void M_Bateria_CargaAlterada(int carga)
        {
            //Atualiza estado da aplicação (visualização da carga da bateria)
            pbBateria.Value = carga;
            this.Title = "Gestor de Bateria - " + carga + "%";
        }

        private void btnCarregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Invocação de método do Model (Interligação View->Model)
                _app.M_Bateria.Carregar();
            }
            catch (OperacaoInvalidaException erro)
            {
                MessageBox.Show(erro.Message, "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDescarregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Invocação de método do Model (Interligação View->Model)
                _app.M_Bateria.Descarregar();
            }
            catch (OperacaoInvalidaException erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //TPC: Exercicio extra aula n. 8
    }
}
