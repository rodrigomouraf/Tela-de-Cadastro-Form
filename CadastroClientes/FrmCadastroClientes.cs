using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes
{
    public partial class FrmCadastroClientes : Form
    {
        public FrmCadastroClientes()
        {
            InitializeComponent();
        }

        private void FrmCadastroClientes_Load(object sender, EventArgs e)
        {

        }
        
        private void btnGravar_Click(object sender, EventArgs e)
        {
            // cria dataset, que pode ser uma coleção de tabelas
            DataSet dataset = new DataSet("Dados");
            // cria a tabela
            DataTable tabela = CriarEstruturaTabela();
            // adiciona tabela ao dataset
            dataset.Tables.Add(tabela);
            // adiciona registros na tabela
            // criar os registros
            DataRow registro = tabela.NewRow();
            registro["Codigo"] = txtCodigo.Text;
            registro["Nome"] = txtNome.Text;
            registro["Fone"] = txtTelefone.Text;
            registro["Email"] = txtEmail.Text;
            tabela.Rows.Add(registro);
            // salvando o cliente em um arquivo xml
            dataset.WriteXml(@".\cliente_" + txtCodigo.Text + ".xml");
        }

        private DataTable CriarEstruturaTabela()
        {
            DataTable tabela = new DataTable("Clientes");
            //cria colunas para a tabela
            tabela.Columns.Add(new DataColumn("Codigo"));
            tabela.Columns.Add(new DataColumn("Nome"));
            tabela.Columns.Add(new DataColumn("Fone"));
            tabela.Columns.Add(new DataColumn("Email"));
            return tabela;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // cria o dataset
            DataSet dataset = new DataSet();
            // le o dataset do disco 
            dataset.ReadXml(@"./Cliente_" + txtCodigo.Text + ".xml");
            // tabela é o primeiro datatable da coleção
            DataTable tabela = dataset.Tables[0];
            // considero o primeiro registro da tabela
            DataRow registro = tabela.Rows[0];
            // mostro dados do registro na tela
            MostrarDadosTela(registro);

        }

        private void MostrarDadosTela(DataRow registro)
        {
            txtCodigo.Text = registro["Codigo"].ToString();
            txtNome.Text = registro["Nome"].ToString();
            txtTelefone.Text = registro["Fone"].ToString();
            txtEmail.Text = registro["Email"].ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //percorrer todos os controles da tela para limpar
            foreach (Control txt in Controls)
                if (txt is TextBox)
                    (txt as TextBox).Clear();
                    
        }
    }
}
