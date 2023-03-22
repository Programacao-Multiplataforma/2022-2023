using System.Windows;

namespace Aula05
{
    /// <summary>
    /// Interaction logic for WindowAdicionar.xaml
    /// </summary>
    public partial class WindowAdicionar : Window
    {
        public Figura FiguraNova { get; private set; }

        public WindowAdicionar()
        {
            InitializeComponent();

            FiguraNova = new Figura();
        }

        private void btnAceitar_Click(object sender, RoutedEventArgs e)
        {            
            FiguraNova.Largura = tbLargura.Text;
            FiguraNova.Altura = tbAltura.Text;

            if (rbQuadrado.IsChecked == true)
                FiguraNova.Nome = "Quadrado";
            else if (rbRetangulo.IsChecked == true)
                FiguraNova.Nome = "Retangulo";
            else
                FiguraNova.Nome = "Circulo";

            this.DialogResult = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
