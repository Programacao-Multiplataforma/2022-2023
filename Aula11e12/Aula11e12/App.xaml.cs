using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aula11e12
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Declaração das propriedades que representam os Models
        public ModelInscricoes ViewModel { get; private set; }

        public App()
        {
            //Instanciação dos Models representados pelas Propriedades
            ViewModel = new ModelInscricoes();
        }
    }
}
