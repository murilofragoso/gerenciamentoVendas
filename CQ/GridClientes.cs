using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CQ
{
    public partial class GridClientes : Form
    {
        public GridClientes()
        {
            InitializeComponent();
            PreencherTabela();
        }

        public static string ClienteAtual { get; set; }

        public void PreencherTabela()
        {
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach(Cliente elemento in RP.PreencerClientes())
            {
                dataGridView1.Rows.Add(elemento.Nome, 
                    elemento.Endereco,
                    elemento.Telefone, 
                    elemento.CEP, 
                    elemento.Email,
                    elemento.CNPJ,
                    elemento.IE);
            }
        }

        public string RetornarCliente()
        {
            return ClienteAtual;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            ClienteAtual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            MessageBox.Show("Selecionado!");
            NovaVenda venda = new NovaVenda();
            venda.Show();
            Visible = false;
        }

        public void HabilidarBotao()
        {
            btnVoltar.Enabled = true;
            btnSelecionar.Enabled = true;
            button1.Enabled = false;
        }
        public void DesabilitarBotao()
        {
            btnVoltar.Enabled = false;
            btnVoltar.Enabled = false;
            button1.Enabled = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            GridProdutos produtos = new GridProdutos();
            produtos.Show();
            produtos.HabilitarBotao(0);
            Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repository rp = new Repository();
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            ClienteAtual = dataGridView1.Rows[indice].Cells[0].Value.ToString();

            if (MessageBox.Show("Deseja excluir este item ?", "Excluir item", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rp.ClearCLiente();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PreencherTabela();
        }


        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach (Cliente elemento in RP.PesquisarClientes(txtPesquisar.Text))
            {
                dataGridView1.Rows.Add(elemento.Nome,
                    elemento.Endereco,
                    elemento.Telefone,
                    elemento.CEP,
                    elemento.Email,
                    elemento.CNPJ,
                    elemento.IE);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            ClienteAtual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            AtualizarCliente att = new AtualizarCliente();
            att.Show();
        }
    }
}
