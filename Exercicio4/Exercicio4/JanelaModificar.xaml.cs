using Exercicio4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Exercicio4
{
    /// <summary>
    /// Interaction logic for JanelaModificar.xaml
    /// </summary>
    public partial class JanelaModificar : Window
    {
        public Aluno Aluno
        {
            get
            {   // usa os valore snas textboxs do formulário para instancia e devolver o Aluno
                return new Aluno { Numero = tbNumero.Text, Nome = tbNome.Text, Curso = tbCurso.Text };
            }
            set
            {   // "distribui" as propriedades do Aluno pelas textboxs do formulário
                tbNumero.Text = value.Numero;
                tbNome.Text = value.Nome;
                tbCurso.Text = value.Curso;
            }
        }

        private App _app;

        public JanelaModificar()
        {
            InitializeComponent();

            _app = App.Current as App;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false; // não se pode usar isto porque "destroi" a janela - close
            this.Hide();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true; // não se pode usar isto porque "destroi" a janela - close
            _app.ViewModel.ModificaDados(this.Aluno);
            this.Hide();
        }
    }
}
