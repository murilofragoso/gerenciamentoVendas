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
    public partial class VerificarLucro : Form
    {
        public VerificarLucro()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            DateTime valor;
            Repository RP = new Repository();
            if (DateTime.TryParse(txtDataFinal.Text, out valor))
            {
                if (DateTime.TryParse(txtDataInicial.Text, out valor))
                {
                    try
                    {
                        lblLucro.Text = "Seu lucro foi de R$ " +
                            RP.VerificarLucro(DateTime.Parse(txtDataInicial.Text), DateTime.Parse(txtDataFinal.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Não existem registros compativeis com estas datas!");
                    }
                }
                else
                    MessageBox.Show("Data Invalida!");
            }
            else
                MessageBox.Show("Data Inválida!");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
