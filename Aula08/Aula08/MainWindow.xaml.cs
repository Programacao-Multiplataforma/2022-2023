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

namespace Aula08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Apontador para App "Camada de Interligação"
        private App _app;
        public MainWindow()
        {
            InitializeComponent();

            //Obtenção da instância da App
            _app = App.Current as App;

            //Subscrição de método da View em event do Model
            _app.M_Texto.TextoValido += M_Texto_TextoValido;
        }

        private void M_Texto_TextoValido(string texto)
        {
            //Atualizada a interface gráfica da View com texto (validado e alterado) recebido do Model
            lbTexto.Items.Add(texto);
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            //Tratamento de exceções
            try
            {
                //Tenta executar método do Model
                _app.M_Texto.ValidarTexto(tbTexto.Text);
            }
            //Caso seja gerada uma exceção no Model a View tenta tratar a exceção
            //catch(FormatException erro)
            //{
            //    //Mensagem exibida ao utilizador com a mensagem do erro que ocorreu
            //    MessageBox.Show(erro.Message);
            //}
            //catch(ArgumentOutOfRangeException erro)
            //{
            //    //Mensagem exibida ao utilizador com a mensagem do erro que ocorreu
            //    MessageBox.Show(erro.Message);
            //}
            catch (TextoInvalidoException erro)
            {
                //Mensagem exibida ao utilizador com a mensagem do erro que ocorreu
                MessageBox.Show(erro.Message);
            }
        }

        //TPC: Fazer exercício extra aula 7
    }
}
