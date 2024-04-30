using System.Runtime.CompilerServices;

namespace WinFormsAppClasse
{
    public partial class FormConta : Form
    {
        // criado um objeto chamado conta do tipo Conta
        Conta conta = new Conta();

        // criada uma lista de conta
        List<Conta> contas = new List<Conta>();

        public FormConta()
        {
            InitializeComponent();
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            conta = new Conta();
            // determinei os atributos do objeto conta
            // obtendo o texto do txtNumeroConta e atribuindo ao NumeroConta
            conta.NumeroConta = int.Parse(txtNumeroConta.Text);
            conta.Nome = txtTitularConta.Text;

            conta.Depositar(100);

            // adicionar a nova conta na lista contas
            contas.Add(conta);

            // carregar a tabela de dados datagridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = contas;

            // limpar os campos da tela
            txtNumeroConta.Clear();
            txtTitularConta.Clear();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            conta.Depositar(100);
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            conta.Sacar(100);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // se o indice da linha for maior ou igual a 9
            // significa que foi selecionada uma linha
            if(e.RowIndex >= 0) 
            {
                // cria uma variavel do tipo conta baseado na lista de contas
                var contaSelecionada = contas[e.RowIndex];

                // atribui o texto para o campo de acordo o numeroConta da conta selecionad
                txtNumeroConta.Text = contaSelecionada.NumeroConta.ToString();
                txtTitularConta.Text = contaSelecionada.Nome;
            }
        }
    }
}
