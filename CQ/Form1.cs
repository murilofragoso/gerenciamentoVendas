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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            NovoCliente NC = new NovoCliente();
            NC.Show();
        }

        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            NovoProduto NP = new NovoProduto();
            NP.Show();
        }

        private void ExibirProdutos_Click(object sender, EventArgs e)
        {
            GridProdutos produtos = new GridProdutos();
            produtos.DesabilitarBotao();
            produtos.Show();
        }

        private void ExibirClientes_Click(object sender, EventArgs e)
        {
            GridClientes clientes = new GridClientes();
            clientes.DesabilitarBotao();
            clientes.Show();
        }

        private void btnAddVenda_Click(object sender, EventArgs e)
        {
            GridProdutos Produto = new GridProdutos();
            Produto.HabilitarBotao(0);
            Produto.Show();
        }

        private void ExibirVendas_Click(object sender, EventArgs e)
        {
            GridVendas venda = new GridVendas();
            venda.Show();
        }

        private void AddFornecedor_Click(object sender, EventArgs e)
        {
            NovoFornecedor fornecedor = new NovoFornecedor();
            fornecedor.Show();
        }

        private void ExibirFornecedores_Click(object sender, EventArgs e)
        {
            GridFornecedores fornecedores = new GridFornecedores();
            fornecedores.Show();
        }

        private void AddCompra_Click(object sender, EventArgs e)
        {
            GridProdutos Produto = new GridProdutos();
            Produto.HabilitarBotao(1);
            Produto.Show();
        }

        private void ExibirCompras_Click(object sender, EventArgs e)
        {
            GridCompras compra = new GridCompras();
            compra.Show();
        }

        private void btnVerificarLucro_Click(object sender, EventArgs e)
        {
            VerificarLucro lucro = new VerificarLucro();
            lucro.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja mesmo sair?", "Confirmar saida", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
