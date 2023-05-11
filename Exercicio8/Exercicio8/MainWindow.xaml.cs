using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Exercicio8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public App _app;

        public MainWindow()
        {
            InitializeComponent();
            _app = App.Current as App;

            // carregar as COMBOBOX com os tipos de garrafas
            cbTipoGarrafa.ItemsSource = Enum.GetValues(typeof(Capacidades)); // para a definição da garrafa
            cbTiposGarrafas.ItemsSource = Enum.GetValues(typeof(Capacidades)); // para a definição da grade

            _app.VM_ViewModel.AlteracaoBasilhame += VM_ViewModel_AlteracaoBasilhame;
        }

        private void VM_ViewModel_AlteracaoBasilhame()
        {
            this.VisualizaGrade();
        }

        private void btnGerarGrade_Click(object sender, RoutedEventArgs e)
        {
            // converte os dados do formulário...
            // .. assumindo que estão bem preenchidos
            Capacidades cap = (Capacidades) Enum.Parse(typeof(Capacidades), cbTiposGarrafas.SelectedItem.ToString());
            int quantidade = int.Parse(tbQuantidade.Text);
            
            // define a base para o Model
            _app.VM_ViewModel.DefineGrade(cap, quantidade);
            // comuta os formulários de interação
            gbGarrafas.IsEnabled = true; // habilita o manuseamento de garrafas
            gbGrade.IsEnabled = false; // desabilita a criação de nova grade
        }

        private void btnRemoveVazia_Click(object sender, RoutedEventArgs e)
        {
            _app.VM_ViewModel.RemoveGarrafa(); // remove CERVEJA VAZIA
        }

        private void btnRemoveCheia_Click(object sender, RoutedEventArgs e)
        {
            _app.VM_ViewModel.RemoveCerveja(); // remove CERVEJA CHEIA
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // converte os dados do formulário...
                // .. assumindo que estão bem preenchidos
                Capacidades cap = (Capacidades)Enum.Parse(typeof(Capacidades), cbTipoGarrafa.SelectedItem.ToString());
                bool cheia = (bool)cbCheia.IsChecked;

                // adiciona a cerveja à grade
                Cerveja nova = new Cerveja(cap, cheia);
                _app.VM_ViewModel.AdicionaCerveja(nova); 
            }
            catch(ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VisualizaGrade()
        {
            wpGrade.Children.Clear();
            foreach(Cerveja c in _app.VM_ViewModel.Grade)
            {
                if(c.Cheia == true) {
                    // button GREEN para representar a garrafa cheia
                    wpGrade.Children.Add(new Button { Content = "C", FontSize = 30, Margin = new Thickness(5), Background=Brushes.LightGreen, Width = 80, Height = 60 });
                }
                else
                {  
                    // button PINK para representar a garrafa vazia
                    wpGrade.Children.Add(new Button { Content = "V", FontSize = 30, Margin = new Thickness(5), Background=Brushes.LightPink, Width = 80, Height = 60 });
                }
            }
        }
    }
}
