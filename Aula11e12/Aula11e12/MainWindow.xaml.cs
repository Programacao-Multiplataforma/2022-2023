using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aula11e12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Apontador para a classe App (Camada de Interligação)
        private App app;
        public MainWindow()
        {
            InitializeComponent();

            //Obtenção do apontador para a classe App (Camada de Interligação)
            app = App.Current as App;

            //Subscrição de método da View em evento do Model
            app.ViewModel.LeituraTerminada += M_Inscricoes_LeituraTerminada;
            app.ViewModel.EscritaTerminada += M_Inscricoes_EscritaTerminada;
            app.ViewModel.InscricaoAtualizada += M_Inscricoes_InscricaoAtualizada;
        }

        private void M_Inscricoes_InscricaoAtualizada()
        {
            //A View exibe mensagem de texto ao utilizador
            MessageBox.Show("Inscrição atualizada!");
            M_Inscricoes_LeituraTerminada();
        }

        private void M_Inscricoes_EscritaTerminada()
        {
            //A View exibe mensagem de texto ao utilizador
            MessageBox.Show("Ficheiro guardado com sucesso!");
        }

        private void M_Inscricoes_LeituraTerminada()
        {
            //Criação dos dois items da treeview
            TreeViewItem inscritos = new TreeViewItem();
            inscritos.Header = "Inscritos";
            inscritos.ExpandSubtree(); // renderiza o nó já aberto
            TreeViewItem naoinscritos = new TreeViewItem();
            naoinscritos.Header = "Não Inscritos";
            naoinscritos.ExpandSubtree(); // renderiza o nó já aberto

            //Percorre a estrutura de dados do Model (estado da aplicação)
            foreach (Aluno al in app.ViewModel.Dados.Values)
            {
                //Coloca na treeview cada aluno no item "Inscritos" ou "Não Inscritos"
                if (al.Inscrito)
                    //inscritos.Items.Add(al.Numero + "-" + al.Nome + "-" + al.Curso);
                    inscritos.Items.Add(al);
                else
                    //naoinscritos.Items.Add(al.Numero + "-" + al.Nome + "-" + al.Curso);
                    naoinscritos.Items.Add(al);
            }

            //apaga dados antigos da treeview
            tvAlunos.Items.Clear();
            //Adiciona items "Inscritos" e "Não Inscritos" na treeview
            tvAlunos.Items.Add(inscritos);
            tvAlunos.Items.Add(naoinscritos);
        }

        private void MenuItem_AbrirTexto_Click(object sender, RoutedEventArgs e)
        {
            //Permite ao utilizador selecionar um ficheiro de texto para abrir
            OpenFileDialog dlg = new OpenFileDialog();
            //Define filtro
            dlg.Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*";
            //Mostra caixa de diálogo ao utilizador
            if (dlg.ShowDialog() == true)
                //Invoca método do Model caso utilizador tenha selecionado botáo abrir (View->Model)
                app.ViewModel.LeituraFicheiroTXT(dlg.FileName);
        }

        private void MenuItem_GuardarXml_Click(object sender, RoutedEventArgs e)
        {
            //Permite ao utilizador selecionar um ficheiro xml para guardar
            SaveFileDialog dlg = new SaveFileDialog();
            //Define filtro
            dlg.Filter = "Ficheiros xml|*.xml|Todos os ficheiros|*.*";
            //Mostra caixa de diálogo ao utilizador
            if (dlg.ShowDialog() == true)
            {
                //Tenta invocar método do Model
                try
                {
                    //Invoca método do Model caso utilizador tenha selecionado botáo guardar (View->Model)
                    app.ViewModel.EscritaFicheiroXML(dlg.FileName);
                }
                //Em caso de erro de operação
                catch (OperacaoInvalidaException erro)
                {
                    //Mostra mensagem de erro ao utilizador
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void MenuItem_AbrirXml_Click(object sender, RoutedEventArgs e)
        {
            //Permite ao utilizador selecionar um ficheiro xml para abrir
            OpenFileDialog dlg = new OpenFileDialog();
            //Define filtro
            dlg.Filter = "Ficheiros xml|*.xml|Todos os ficheiros|*.*";
            //Mostra caixa de diálogo ao utilizador
            if (dlg.ShowDialog() == true)
                //Invoca método do Model caso utilizador tenha selecionado botáo abrir (View->Model)
                app.ViewModel.LeituraFicheiroXML(dlg.FileName);
        }

        private void MenuItem_GuardarTexto_Click(object sender, RoutedEventArgs e)
        {
            //Permite ao utilizador selecionar um ficheiro de texto para guardar
            SaveFileDialog dlg = new SaveFileDialog();
            //Define filtro
            dlg.Filter = "Ficheiros de texto|*.txt|Todos os ficheiros|*.*";
            //Mostra caixa de diálogo ao utilizador
            if (dlg.ShowDialog() == true)
            {
                //Tenta invocar método do Model
                try
                {
                    //Invoca método do Model caso utilizador tenha selecionado botáo guardar (View->Model)
                    app.ViewModel.EscritaFicheiroTXT(dlg.FileName);
                }
                //Em caso de erro de operação
                catch (OperacaoInvalidaException erro)
                {
                    //Mostra mensagem de erro ao utilizador
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void tvAlunos_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Verifica se foi selecionado um item válido na treeview
            if (tvAlunos.SelectedValue != null && tvAlunos.SelectedItem is Aluno)
                //Invoca métodos do Model de alteração de inscrição (View->Model)
                //app.M_Inscricoes.AlteraInscricao(tvAlunos.SelectedValue.ToString().Split('-')[0]);
                app.ViewModel.AlteraInscricao((tvAlunos.SelectedValue as Aluno).Numero);
        }

        //TPC: Fazer exercicios extra aula 9 e 10
        //1- Fazer na aula/casa Alterar Inscricao de aluno selecionado na treeview
        //2- Mostrar mensagem ao utilizador quando ficheiro guardado com sucesso
        //3- Verificar se existem dados para serem guardados em ficheiro
        //      Caso não existam deve ser mostrada mensagem de erro (utilizar mecanismos exceções)
    }
}
