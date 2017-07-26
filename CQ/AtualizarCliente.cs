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
    public partial class AtualizarCliente : Form
    {
        public AtualizarCliente()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (VerificarVazio())
            {
                Repository RP = new Repository();
                RP.UpdateCLiente(
                    Int64.Parse(txtCNPJ.Text),
                    txtEnd.Text,
                    Int64.Parse(txtCEP.Text),
                    Int64.Parse(txtTel.Text),
                    txtEmail.Text,
                    Int64.Parse(txtIE.Text));

                MessageBox.Show("Atualização realizada com sucesso!");
                Visible = false;
            }
        }

        public bool VerificarVazio()
        {
            if (string.IsNullOrEmpty(txtCEP.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCNPJ.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtEnd.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtIE.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else
                return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
