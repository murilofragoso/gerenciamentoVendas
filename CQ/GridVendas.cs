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
    public partial class GridVendas : Form
    {
        public GridVendas()
        {
            InitializeComponent();
            PreencherTabela();
        }

        public void PreencherTabela()
        {
            decimal texto = 0;
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach(Venda elemento in RP.PreencherVendas())
            {
                dataGridView1.Rows.Add(
                    elemento.NomeCliente,
                    elemento.NomeProduto,
                    elemento.Quantidade,
                    elemento.DescontoEditado,
                    elemento.TotalEditado,
                    elemento.Data.ToShortDateString());
                texto = (texto + elemento.Total);
            }

            txtTotal.Text = $"{texto:N}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Repository rp = new Repository();
            if(MessageBox.Show("Deseja excluir TODOS os itens ? todos os dados serão perdidos!!","Limpar dados",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rp.ClearAllVendas();
            }
        }

        private void btnClearCliente_Click(object sender, EventArgs e)
        {
            DataLimpeza data = new DataLimpeza();
            data.Show();
            data.DefinirVenda();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            decimal texto = 0;
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach (Venda elemento in RP.PesquisarClienteVendas(txtPesquisar.Text))
            {
                dataGridView1.Rows.Add(
                    elemento.NomeCliente,
                    elemento.NomeProduto,
                    elemento.Quantidade,
                    elemento.DescontoEditado,
                    elemento.TotalEditado,
                    elemento.Data.ToShortDateString());
                 texto = (texto + elemento.Total);
            }

            txtTotal.Text = $"{texto:N}";

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PreencherTabela();
        }

        private void btnPesquisarData_Click(object sender, EventArgs e)
        {
            decimal texto = 0;
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach (Venda elemento in RP.PesquisarDataVendas(Convert.ToDateTime(txtData1.Text), Convert.ToDateTime(txtData2.Text)))
            {
                dataGridView1.Rows.Add(
                    elemento.NomeCliente,
                    elemento.NomeProduto,
                    elemento.Quantidade,
                    elemento.DescontoEditado,
                    elemento.TotalEditado,
                    elemento.Data.ToShortDateString());
                texto = (texto + elemento.Total);
            }

            txtTotal.Text = $"{texto:N}";
        }
    }
}
