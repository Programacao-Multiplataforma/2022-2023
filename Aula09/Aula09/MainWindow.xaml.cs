using System.Windows;
using System.Windows.Controls;

namespace Aula09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Apontador para classe App (Camada de Interligação)
        private App _app;
        public MainWindow()
        {
            InitializeComponent();

            //Inicialização do apontador para App (Camada de Interligação)
            _app = App.Current as App;

            //Suscrição de um método da View num evento do Model
            _app.M_Escola.TerminadaInicializacao += M_Escola_TerminadaInicializacao;
        }

        private void M_Escola_TerminadaInicializacao()
        {
            //Atualização da View com o estado da aplicação do Model
            tbEscola.Text = _app.M_Escola.Escola;
            cbDepartamentos.Items.Clear();

            //foreach (ModelDepartamento dep in app.M_Escola.Departamentos)
            //Utilização de inumerador/iterador - Permite abstração da estrutura de dados do Model
            foreach (ModelDepartamento dep in _app.M_Escola)
                //cbDepartamentos.Items.Add(dep.Designacao); // versão em que apenas é usada a designação (string)
                cbDepartamentos.Items.Add(dep); // versão em que é usado o departamento (obriga a alteração do template - XAML)
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Pedido incialização do estado da aplicação (Model)
            _app.M_Escola.Inicializar();
        }

        private void cbDepartamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Atualização da View com dados do Model
            //sbiNDocentes.Content = "N.º Docentes: " + _app.M_Escola.ObterDocentes(cbDepartamentos.SelectedIndex);
            
            // esta versão tira partido de a informação do Departamento estar toda na Combobox
            sbiNDocentes.Content = "N.º Docentes: " + (cbDepartamentos.SelectedItem as ModelDepartamento).Docentes;
        }
    }
}
