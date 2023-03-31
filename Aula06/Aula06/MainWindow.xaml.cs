using System;
using System.Windows;

namespace Aula06
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App app;
        public MainWindow()
        {
            InitializeComponent();

            //Ligação à App
            app = App.Current as App;

            //Subscrição de um método no evento do Model
            // leitura da notificação de erro na submissão do valor
            app.Model_Classificacoes.NotaComValorErrado += Model_Classificacoes_NotaComValorErrado;
        }

        private void Model_Classificacoes_NotaComValorErrado(string mensagem)
        {
            MessageBox.Show(mensagem, "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            app.View_ListarNotas.Show();
            app.View_ListarAvaliacoes.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            app.View_ListarNotas.Close();
            app.View_ListarAvaliacoes.Close();
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            app.Model_Classificacoes.Inserir(tbNota.Text);
        }

        //TPC: Validar nota introduzida pelo utilizador. Caso seja inválida mostrar mensagem ao utilizador
        //TPC: Fazer ex: 3 e 4 extra aula
    }
}
