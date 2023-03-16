using System.Windows;

namespace Aula04
{
    /// <summary>
    /// Interaction logic for WindowFiguras.xaml
    /// </summary>
    public partial class WindowFiguras : Window
    {
        public string Figura { get; private set; } // propriedade para "partilhar" o valor selecionado na combobox

        public WindowFiguras()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            if (cbFiguras.SelectedIndex != -1) // existe algum elemento selecionado?
            {
                Figura = cbFiguras.Text;

                this.DialogResult = true; // fecha a janela e devolve o valor TRUE
            }
            else
            {
                this.DialogResult = false;  // fecha a janela e devolve o valor FALSE
            }
            //this.Close();
        }
    }
}
