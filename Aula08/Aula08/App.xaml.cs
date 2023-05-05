using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aula08
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Propriedades que representam os Models
        public ModelTexto M_Texto { get; private set; }

        public App()
        {
            //Instanciar Models
            M_Texto = new ModelTexto();
        }
    }
}
