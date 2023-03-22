﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Aula05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Figura> Lista { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Lista = new List<Figura>();           
        }

        private void FigurasAdicionar_Click(object sender, RoutedEventArgs e)
        {
            WindowAdicionar dlg = new WindowAdicionar();

            if (dlg.ShowDialog() == true)
            {
                //lbFiguras.Items.Add(dlg.FiguraNova.Nome);
                lbFiguras.Items.Add(dlg.FiguraNova);

                Lista.Add(dlg.FiguraNova);
            }
        }

        private void lbFiguras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int figuraselecionada = lbFiguras.SelectedIndex;
            Figura fig = Lista[figuraselecionada];
            sbiDimensoes.Content = "Largura: " + fig.Largura + " Altura: " + fig.Altura;
        }

        //TPC: Desenhar figura selecionada com as respetivas dimensões e validar
        //a largura e altura inseridas pelo utilizador
    }
}
