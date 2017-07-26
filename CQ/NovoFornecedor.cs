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
    public partial class NovoFornecedor : Form
    {
        public NovoFornecedor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (VerificarVazio())
            {
                Repository RP = new Repository();
                RP.AdicionarFornecedor(
                    txtNome.Text,
                    Int64.Parse(txtCNPJ.Text),
                    txtEndereco.Text,
                    Int64.Parse(txtCEP.Text),
                    Int64.Parse(txtTel.Text),
                    txtEmail.Text,
                    Int64.Parse(txtIE.Text)
                    );
                MessageBox.Show("Cadastrado com sucesso!");
                txtCEP.Text = "";
                txtCNPJ.Text = "";
                txtEmail.Text = "";
                txtEndereco.Text = "";
                txtIE.Text = "";
                txtNome.Text = "";
                txtTel.Text = "";
            }
        }

        public bool VerificarVazio()
        {
            if (string.IsNullOrEmpty(txtCEP.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCNPJ.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else if (string.IsNullOrEmpty(txtEndereco.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else if (string.IsNullOrEmpty(txtIE.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }
            else
                return true;
        }
    }
}
