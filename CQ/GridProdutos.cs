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
    public partial class GridProdutos : Form
    {
        public GridProdutos()
        {
            InitializeComponent();
            PreencherTabela();
        }

        public static string Produtoatual { get; set; }
        public static int  CaminhoSelecionar { get; set; }
        public static int QuantidadeEstoque { get; set; }

        public void PreencherTabela()
        {
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach( Produto elemento in RP.PreencerProdutos())
            {
                dataGridView1.Rows.Add(
                    elemento.Nome,
                    elemento.ValorEditado,
                    elemento.Estoque);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Produtoatual = dataGridView1.SelectedCells.ToString();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            Produtoatual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            QuantidadeEstoque = Convert.ToInt32(dataGridView1.Rows[indice].Cells[2].Value);
            MessageBox.Show("Selecionado!");
            if (CaminhoSelecionar == 0)
            {
                GridClientes cliente = new GridClientes();
                cliente.HabilidarBotao();
                cliente.Show();
            }
            else if (CaminhoSelecionar == 1)
            {
                GridFornecedores fornecedor = new GridFornecedores();
                fornecedor.HabilidarBotao();
                fornecedor.Show();
            }
            Visible = false;
        }

        public void HabilitarBotao(int caminhobotao)
        {
            if(caminhobotao == 0)
            {
                CaminhoSelecionar = 0;
            }
            else if (caminhobotao == 1)
            {
                CaminhoSelecionar = 1;
            }
            btnSelecionar.Enabled = true;
        }
        public void DesabilitarBotao()
        {
            btnSelecionar.Enabled = false;
        }

        public string RetornarProduto()
        {
            return Produtoatual;
        }
        
        public int RetornarEstoque()
        {
            return QuantidadeEstoque;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach (Produto elemento in RP.PesquisarProdutos(txtPesquisar.Text))
            {
                dataGridView1.Rows.Add(
                    elemento.Nome,
                    elemento.ValorEditado,
                    elemento.Estoque);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            Produtoatual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            AtualizarProduto att = new AtualizarProduto();
            att.Show();
        }

        private void btnAtt_Click(object sender, EventArgs e)
        {
            PreencherTabela();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Repository rp = new Repository();
            DataGridViewRow linhaatual = dataGridView1.CurrentRow;
            int indice = linhaatual.Index;
            Produtoatual = dataGridView1.Rows[indice].Cells[0].Value.ToString();
            if (MessageBox.Show("Deseja excluir este item?","Excluir item",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rp.ClearProduto();
            }
        }
    }
}
