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
                cbDepartamentos.Items.Add(dep.Designacao);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Pedido incialização do estado da aplicação (Model)
            _app.M_Escola.Inicializar();
        }

        private void cbDepartamentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Atualização da View com dados do Model
            sbiNDocentes.Content = "N.º Docentes: " + _app.M_Escola.ObterDocentes(cbDepartamentos.SelectedIndex);
        }
    }
}
