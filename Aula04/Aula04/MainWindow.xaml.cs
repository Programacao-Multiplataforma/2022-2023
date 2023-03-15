using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Aula04
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
        private void FigurasAdicionar_Click(object sender, RoutedEventArgs e)
        {
            WindowFiguras dlg = new WindowFiguras();

            if (dlg.ShowDialog() == true)
            {
                lbFiguras.Items.Add(dlg.Figura);
                //canvasRepresentacao.Children.Clear();

                DesenhaFigura(dlg.Figura);

                //switch (dlg.Figura)
                //{
                //    case "Quadrado":
                //        Rectangle quadrado = new Rectangle();
                //        quadrado.Width = 50;
                //        quadrado.Height = 50;
                //        quadrado.Stroke = Brushes.Red;
                //        canvasRepresentacao.Children.Add(quadrado);
                //        break;
                //    case "Retangulo":
                //        Rectangle retangulo = new Rectangle();
                //        retangulo.Width = 100;
                //        retangulo.Height = 50;
                //        retangulo.Stroke = Brushes.Green;
                //        canvasRepresentacao.Children.Add(retangulo);
                //        break;
                //    case "Circulo":
                //        Ellipse circulo = new Ellipse();
                //        circulo.Width = 50;
                //        circulo.Height = 50;
                //        circulo.Stroke = Brushes.Blue;
                //        canvasRepresentacao.Children.Add(circulo);
                //        break;
                //}
            }
        }

        private void FigurasSair_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem a certeza?", "Sair", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void lbFiguras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbFiguras.SelectedItems.Count > 0)
            {
                DesenhaFigura(lbFiguras.SelectedItem.ToString());
            }
        }

        private void DesenhaFigura(string? figura)
        {
            canvasRepresentacao.Children.Clear();

            switch (figura)
            {
                case "Quadrado":
                    Rectangle quadrado = new Rectangle();
                    quadrado.Width = 50;
                    quadrado.Height = 50;
                    quadrado.Stroke = Brushes.Red;
                    canvasRepresentacao.Children.Add(quadrado);
                    break;
                case "Retangulo":
                    Rectangle retangulo = new Rectangle();
                    retangulo.Width = 100;
                    retangulo.Height = 50;
                    retangulo.Stroke = Brushes.Green;
                    canvasRepresentacao.Children.Add(retangulo);
                    break;
                case "Circulo":
                    Ellipse circulo = new Ellipse();
                    circulo.Width = 50;
                    circulo.Height = 50;
                    circulo.Stroke = Brushes.Blue;
                    canvasRepresentacao.Children.Add(circulo);
                    break;
            }
        }

        private void FigurasRemover_Click(object sender, RoutedEventArgs e)
        {
            if (lbFiguras.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Tem a certeza?", "Apagar Figura", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    lbFiguras.Items.Remove(lbFiguras.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Tem de selecionar uma Figura", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuadroLimpar_Click(object sender, RoutedEventArgs e)
        {
            canvasRepresentacao.Children.Clear();
        }
    }
}
