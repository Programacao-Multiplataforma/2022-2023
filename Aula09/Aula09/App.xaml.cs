using System.Windows;

namespace Aula09
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Models
        public ModelEscola M_Escola { get; private set; }

        public App()
        {
            //Instanciação dos Models
            M_Escola = new ModelEscola();
        }
    }
}
