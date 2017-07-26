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
    public partial class NovoProduto : Form
    {
        public NovoProduto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarVazio())
            {
                Repository RP = new Repository();
                RP.AdicionarProduto(
                    txtNome.Text,
                    decimal.Parse(txtVpadrao.Text),
                    int.Parse(txtEstoque.Text));

                MessageBox.Show("Cadastro realizado com sucesso!");
                txtEstoque.Text = "";
                txtNome.Text = "";
                txtVpadrao.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        public bool VerificarVazio()
        {
            if (string.IsNullOrEmpty(txtEstoque.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtVpadrao.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else
                return true;
        }
    }
}
