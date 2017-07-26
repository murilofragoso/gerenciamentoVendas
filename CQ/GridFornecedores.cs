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
    public partial class GridFornecedores : Form
    {
        public GridFornecedores()
        {
            InitializeComponent();
            PreencherTabela();
        }

        public static string FornecedorAtual { get; set; }

        public void PreencherTabela()
        {
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach(Fornecedor elemento in RP.PreencherFornecedores())
            {
                dataGridView1.Rows.Add(
                    elemento.Nome,
                    elemento.CNPJ,
                    elemento.Endereco,
                    elemento.CEP,
                    elemento.Telefone,
                    elemento.Email,
                    elemento.IE);
            }
        }

        public void HabilidarBotao()
        {
            btnVoltar.Enabled = true;
            btnSelecionar.Enabled = true;
            btnExcluir.Enabled = false;
        }
        public void DesabilitarBotao()
        {
            btnVoltar.Enabled = false;
            btnVoltar.Enabled = false;
            btnExcluir.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            FornecedorAtual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            MessageBox.Show("Selecionado!");
            NovaCompra compra = new NovaCompra();
            compra.Show();
            Visible = false;
        }

        public string RetornarFornecedor()
        {
            return FornecedorAtual;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            GridProdutos produtos = new GridProdutos();
            produtos.Show();
            produtos.HabilitarBotao(1);
            Visible = false;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Repository rp = new Repository();
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            FornecedorAtual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            if(MessageBox.Show("Deseja excluir este item ?","Excluir item",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rp.ClearFornecedor();
            }
        }

        private void btnAttLista_Click(object sender, EventArgs e)
        {
            PreencherTabela();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach (Fornecedor elemento in RP.PesquisarFornecedores(txtPesquisar.Text))
            {
                dataGridView1.Rows.Add(
                    elemento.Nome,
                    elemento.CNPJ,
                    elemento.Endereco,
                    elemento.CEP,
                    elemento.Telefone,
                    elemento.Email,
                    elemento.IE);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            FornecedorAtual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            AtualizarFornecedor att = new AtualizarFornecedor();
            att.Show();
        }
    }
}
