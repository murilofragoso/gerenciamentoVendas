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
    public partial class GridCompras : Form
    {
        public GridCompras()
        {
            InitializeComponent();
            PreencherTabela();
        }

        public void PreencherTabela()
        {
            decimal texto = 0;
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach(Compra elemento in RP.PreencherCompras())
            {
                dataGridView1.Rows.Add(
                    elemento.Nome_Fornecedor,
                    elemento.Nome_Produto,
                    elemento.Quantidade,
                    elemento.ValorEditado,
                    elemento.Data.ToShortDateString());
                texto = (texto + elemento.Valor_Pago);
            }

            txtTotal.Text = $"{texto:N}";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Repository rp = new Repository();
            if(MessageBox.Show("Deseja excluir TODOS os itens ? todos os dados serão perdidos!!","Limpar dados",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                rp.ClearAllCompras();
            }
        }

        private void btnClearCliente_Click(object sender, EventArgs e)
        {
            DataLimpeza data = new DataLimpeza();
            data.Show();
            data.DefinirCompra();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            decimal texto = 0;
            dataGridView1.Rows.Clear();
            Repository RP = new Repository();
            foreach (Compra elemento in RP.PesquisarFornecedoresCompras(txtPesquisar.Text))
            {
                dataGridView1.Rows.Add(
                    elemento.Nome_Fornecedor,
                    elemento.Nome_Produto,
                    elemento.Quantidade,
                    elemento.ValorEditado,
                    elemento.Data.ToShortDateString());
                texto = (texto + elemento.Valor_Pago);
            }

            txtTotal.Text = $"{texto:N}";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
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
            foreach (Compra elemento in RP.PesquisarDataCompras(Convert.ToDateTime(txtData1.Text), Convert.ToDateTime(txtData2.Text)))
            {
                dataGridView1.Rows.Add(
                    elemento.Nome_Fornecedor,
                    elemento.Nome_Produto,
                    elemento.Quantidade,
                    elemento.ValorEditado,
                    elemento.Data.ToShortDateString());
                texto = (texto + elemento.Valor_Pago);
            }

            txtTotal.Text = $"{texto:N}";
        }
    }
}
