using System.Windows;

namespace WpfApp
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

        private void btnMover_Click(object sender, RoutedEventArgs e)
        {
            tbValor2.Text = tbValor1.Text;

            //tbValor1.Text = "";
            tbValor1.Clear();
        }
    }
}
