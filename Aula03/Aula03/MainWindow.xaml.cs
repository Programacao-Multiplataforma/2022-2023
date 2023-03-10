using System;
using System.Windows;

namespace Aula03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            int valor1 = Convert.ToInt32(tbValor1.Text);
            int valor2 = Convert.ToInt32(tbValor2.Text);

            //tbResultado.Text = Convert.ToString(valor1 + valor2);
            tbResultado.Text = (valor1 + valor2).ToString();

            //ComboBox
            cbResultados.Items.Add(tbResultado.Text);

            //ListBox
            lbResultados.Items.Add(tbResultado.Text);

            //ListView
            lvValores.Items.Add(tbResultado.Text);
            //TPC: Adicionar dados com múltiplas colunas

            //TreeView
            tvResultados.Items.Add(tbResultado.Text);

            //TPC: Adicionar resultados como subnós da TreeView
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            // condicionar o eliminação dos valores à confirmação por parte do utilizador
            MessageBoxResult opcao = MessageBox.Show(
                "Tem a certeza que pretende eliminar os números?",
                "Limpar números",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (opcao == MessageBoxResult.Yes)
            {
                //tbValor1.Text = "";
                //tbValor2.Text = "";
                //tbResultado.Text = "";
                tbValor1.Clear();
                tbValor2.Clear();
                tbResultado.Clear();

                //ComboBox
                cbResultados.Items.Clear();

                //ListBox
                lbResultados.Items.Clear();

                //ListView
                lvValores.Items.Clear();

                //TreeView
                tvResultados.Items.Clear();
            }
        }

        //EXTRA AULA: EXERCÍCIO 1
    }

}
