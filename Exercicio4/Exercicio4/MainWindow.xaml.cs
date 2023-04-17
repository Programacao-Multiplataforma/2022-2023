using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercicio4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App _app;

        public MainWindow()
        {
            InitializeComponent();

            _app = App.Current as App;

            this.Loaded += MainWindow_Loaded; // para carregar os dados do ficheiro
            _app.ViewModel.LeituraTerminada += ViewModel_LeituraTerminada;
            _app.ViewModel.AlteracaoEfetuada += ViewModel_AlteracaoEfetuada;
        }

        private void ViewModel_AlteracaoEfetuada(Models.Aluno aluno)
        {
            tbNumero.Text = aluno.Numero;
            tbNome.Text = aluno.Nome;
            tbCurso.Text = aluno.Curso;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // inicializar os dados a partir do ficheiro "ficheiro.txt"
            _app.ViewModel.LerFicheiro("ficheiro.txt");
        }

        private void ViewModel_LeituraTerminada()
        {
            tbNumero.Text = _app.ViewModel.Dados.Numero;
            tbNome.Text = _app.ViewModel.Dados.Nome;
            tbCurso.Text = _app.ViewModel.Dados.Curso;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            // carrega a janela (já instanciada na App) com os dados do Model 
            _app.View_Modificar.Aluno = _app.ViewModel.Dados;
            //if(_app.View_Modificar.ShowDialog() == true) 
            //{
            //    _app.ViewModel.ModificaDados(_app.View_Modificar.Aluno);
            //}
            _app.View_Modificar.ShowDialog(); // apenas se usa isto porque a ViewModificar já atualiza o Model
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult opcao = MessageBox.Show("Vai abandonar o programa.\nTem a certeza?", 
                                                        "Abandonar o Programa", 
                                                        MessageBoxButton.OKCancel, 
                                                        MessageBoxImage.Question);

            if (opcao == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}
