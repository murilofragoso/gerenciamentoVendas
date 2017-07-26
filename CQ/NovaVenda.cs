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
    public partial class NovaVenda : Form
    {
        public NovaVenda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime valor;
            if (VerificarVazio())
            {
                GridProdutos produto = new GridProdutos();
                if (int.Parse(txtQuantidade.Text) > produto.RetornarEstoque())
                {
                    MessageBox.Show("Quantidade digitada é maior que o estoque atual !");
                }
                else
                {
                    if (DateTime.TryParse(txtData.Text, out valor))
                    {
                        Repository RP = new Repository();
                        RP.AdicionarVenda(
                            int.Parse(txtQuantidade.Text),
                            double.Parse(txtDesconto.Text),
                            Convert.ToDateTime(txtData.Text));
                        RP.DecrementarEstoque(int.Parse(txtQuantidade.Text));
                        MessageBox.Show("Cadastro Concluido!");
                        Visible = false;
                    }
                    else
                        MessageBox.Show("Data invalida!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GridClientes cliente = new GridClientes();
            cliente.Show();
            cliente.HabilidarBotao();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        public bool VerificarVazio()
        {
            txtData.Mask = "";
            if (string.IsNullOrEmpty(txtData.Text))
            {
                txtData.Mask = "00/00/0000";
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtDesconto.Text))
            {
                txtData.Mask = "00/00/0000";
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                txtData.Mask = "00/00/0000";
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else
            {
                txtData.Mask = "00/00/0000";
                return true;
            }
        }
    }
}
