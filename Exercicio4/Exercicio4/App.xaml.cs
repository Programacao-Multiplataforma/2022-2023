using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Exercicio4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // ViewModels
        public ViewModel ViewModel { get; private set; }

        // Views
        public JanelaModificar View_Modificar { get; private set; }
        
        public App()
        {
            // instanciar todas as entidades excetuando a janela principal
            ViewModel = new ViewModel();

            View_Modificar = new JanelaModificar();
        }
    }
}
