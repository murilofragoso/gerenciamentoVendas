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
    public partial class DataLimpeza : Form
    {
        public DataLimpeza()
        {
            InitializeComponent();
        }

        public string DefinirTabela { get; set; }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            Repository RP = new Repository();
            DateTime valor;
            if (DateTime.TryParse(txtDataInicial.Text, out valor))
            {
                if (DateTime.TryParse(txtDataFinal.Text, out valor))
                {
                    if (DefinirTabela == "Venda")
                        RP.ClearParteVendas(Convert.ToDateTime(txtDataInicial.Text), Convert.ToDateTime(txtDataFinal.Text));
                    if (DefinirTabela == "Compra")
                        RP.ClearParteCompras(Convert.ToDateTime(txtDataInicial.Text), Convert.ToDateTime(txtDataFinal.Text));
                }
                else
                    MessageBox.Show("Data invalida!");
            }
            else
                MessageBox.Show("Data invalida!");
        }

        public void DefinirVenda()
        {
            DefinirTabela = "Venda";
        }

        public void DefinirCompra()
        {
            DefinirTabela = "Compra";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
