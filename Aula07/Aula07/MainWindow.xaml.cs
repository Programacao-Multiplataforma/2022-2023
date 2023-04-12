using Microsoft.Win32;
using System.Windows;

namespace Aula07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Variável que representa a camada de "Interligação" (App)
        private App app;

        public MainWindow()
        {
            InitializeComponent();

            //Apontador para a camada de "Interligação" (App)
            app = App.Current as App;

            //Subscrição de método em evento
            app.Model_Ficheiro.LeituraTerminada += Model_Ficheiro_LeituraTerminada;
            app.Model_Ficheiro.EscritaTerminada += Model_Ficheiro_EscritaTerminada;
        }

        private void Model_Ficheiro_EscritaTerminada()
        {
            //Exibição na View do estado da aplicação (Model)
            MessageBox.Show("Ficheiro guardado!!!");
        }

        private void Model_Ficheiro_LeituraTerminada()
        {
            //Exibição na View do estado da aplicação (Model)
            tbFicheiro.Text = app.Model_Ficheiro.Texto;
        }

        private void btnAbrir_Click(object sender, RoutedEventArgs e)
        {
            //Dialog do utilizador de seleção de ficheiro para leitura
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ficheiros de texto (*.txt)|*.txt|Todos of ficheiros (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                //Invoca o método do Model (Ligação View->Model)
                app.Model_Ficheiro.LeituraFicheiro(dlg.FileName);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Dialog do utilizador de seleção de ficheiro para escrita
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros de texto (*.txt)|*.txt|Todos of ficheiros(*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {
                //Invoca o método do Model (Ligação View->Model)
                app.Model_Ficheiro.EscritaFicheiro(dlg.FileName, tbFicheiro.Text);
            }

        }

        //TPC: Exercícios extra aula 5 e 6
    }
}
