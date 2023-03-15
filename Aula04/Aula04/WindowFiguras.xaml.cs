using System.Windows;

namespace Aula04
{
    /// <summary>
    /// Interaction logic for WindowFiguras.xaml
    /// </summary>
    public partial class WindowFiguras : Window
    {
        public string Figura { get; private set; }
        public WindowFiguras()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            if (cbFiguras.SelectedIndex != -1)
            {
                Figura = cbFiguras.Text;

                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
