namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonMover_Click(object sender, EventArgs e)
        {
            tbValor2.Text = tbValor1.Text;

            //textBoxValor1.Text = "";
            tbValor1.Clear();

            MessageBox.Show("Texto movido!!!");
            ;
        }
    }
}