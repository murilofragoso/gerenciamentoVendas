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
    public partial class NovoCliente : Form
    {
        public NovoCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarVazio())
            {
                Repository RP = new Repository();
                RP.AdicionarCLiente(
                    txtNome.Text,
                    Int64.Parse(txtCNPJ.Text),
                    txtEnd.Text,
                    Int64.Parse(txtCEP.Text),
                    Int64.Parse(txtTel.Text),
                    txtEmail.Text,
                    Int64.Parse(txtIE.Text));

                MessageBox.Show("Cadastro realizado com sucesso!");
                txtCEP.Text = "";
                txtCNPJ.Text = "";
                txtEmail.Text = "";
                txtEnd.Text = "";
                txtIE.Text = "";
                txtNome.Text = "";
                txtTel.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        public bool VerificarVazio()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return false;
            }
            else if (string.IsNullOrEmpty(txtCEP.Text))
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
    }
}
