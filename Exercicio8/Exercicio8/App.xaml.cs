using System.Windows;

namespace Exercicio8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Models
        public ViewModel VM_ViewModel { get; private set; }

        public App()
        {
            VM_ViewModel = new ViewModel();
        }
    }
}
