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
    public partial class NovaCompra : Form
    {
        public NovaCompra()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            GridFornecedores fornecedor = new GridFornecedores();
            fornecedor.Show();
            fornecedor.HabilidarBotao();
            Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DateTime valor;
            if (VerificarVazio())
            {
                if (DateTime.TryParse(txtData.Text, out valor))
                {
                    Repository RP = new Repository();
                    RP.AdicionarCompra(
                        int.Parse(txtQuantidade.Text),
                        double.Parse(txtValorPago.Text),
                        DateTime.Parse(txtData.Text));
                    RP.IncrementarEstoque(int.Parse(txtQuantidade.Text));
                    MessageBox.Show("Cadastro Completo!");
                    Visible = false;
                }
                else
                    MessageBox.Show("Data Invalida!");
            }
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
            else if (string.IsNullOrEmpty(txtQuantidade.Text))
            {
                txtData.Mask = "00/00/0000";
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtValorPago.Text))
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
