using System.Windows;

namespace Aula10
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Models
        public ModelBateria M_Bateria { get; private set; }

        public App()
        {
            //Inicialização dos Models
            M_Bateria = new ModelBateria();
        }
    }
}
