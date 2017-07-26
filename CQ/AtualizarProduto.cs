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
    public partial class AtualizarProduto : Form
    {
        public AtualizarProduto()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (VerificarVazio())
            {
                Repository RP = new Repository();
                RP.UpdateProduto(Convert.ToDecimal(txtValor.Text), Convert.ToInt32(txtEstoque.Text));

                MessageBox.Show("Atualização concluida com sucesso!");
                Visible = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
            else if (string.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else
                return true;
        }
    }
}
