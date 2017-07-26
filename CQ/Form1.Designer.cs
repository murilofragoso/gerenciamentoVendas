namespace CQ
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddCliente = new System.Windows.Forms.Button();
            this.btnAddProduto = new System.Windows.Forms.Button();
            this.ExibirProdutos = new System.Windows.Forms.Button();
            this.ExibirClientes = new System.Windows.Forms.Button();
            this.btnAddVenda = new System.Windows.Forms.Button();
            this.ExibirVendas = new System.Windows.Forms.Button();
            this.AddFornecedor = new System.Windows.Forms.Button();
            this.AddCompra = new System.Windows.Forms.Button();
            this.ExibirFornecedores = new System.Windows.Forms.Button();
            this.ExibirCompras = new System.Windows.Forms.Button();
            this.btnVerificarLucro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddCliente
            // 
            this.btnAddCliente.Location = new System.Drawing.Point(39, 211);
            this.btnAddCliente.Name = "btnAddCliente";
            this.btnAddCliente.Size = new System.Drawing.Size(82, 48);
            this.btnAddCliente.TabIndex = 20;
            this.btnAddCliente.Text = "Adicionar Cliente";
            this.btnAddCliente.UseVisualStyleBackColor = true;
            this.btnAddCliente.Click += new System.EventHandler(this.btnAddCliente_Click);
            // 
            // btnAddProduto
            // 
            this.btnAddProduto.Location = new System.Drawing.Point(39, 35);
            this.btnAddProduto.Name = "btnAddProduto";
            this.btnAddProduto.Size = new System.Drawing.Size(82, 48);
            this.btnAddProduto.TabIndex = 1;
            this.btnAddProduto.Text = "Adicionar Produto";
            this.btnAddProduto.UseVisualStyleBackColor = true;
            this.btnAddProduto.Click += new System.EventHandler(this.btnAddProduto_Click);
            // 
            // ExibirProdutos
            // 
            this.ExibirProdutos.Location = new System.Drawing.Point(39, 89);
            this.ExibirProdutos.Name = "ExibirProdutos";
            this.ExibirProdutos.Size = new System.Drawing.Size(82, 48);
            this.ExibirProdutos.TabIndex = 2;
            this.ExibirProdutos.Text = "Exibir Produtos";
            this.ExibirProdutos.UseVisualStyleBackColor = true;
            this.ExibirProdutos.Click += new System.EventHandler(this.ExibirProdutos_Click);
            // 
            // ExibirClientes
            // 
            this.ExibirClientes.Location = new System.Drawing.Point(39, 265);
            this.ExibirClientes.Name = "ExibirClientes";
            this.ExibirClientes.Size = new System.Drawing.Size(82, 48);
            this.ExibirClientes.TabIndex = 3;
            this.ExibirClientes.Text = "Exibir Clientes";
            this.ExibirClientes.UseVisualStyleBackColor = true;
            this.ExibirClientes.Click += new System.EventHandler(this.ExibirClientes_Click);
            // 
            // btnAddVenda
            // 
            this.btnAddVenda.Location = new System.Drawing.Point(187, 35);
            this.btnAddVenda.Name = "btnAddVenda";
            this.btnAddVenda.Size = new System.Drawing.Size(82, 48);
            this.btnAddVenda.TabIndex = 0;
            this.btnAddVenda.Text = "Adicionar Venda";
            this.btnAddVenda.UseVisualStyleBackColor = true;
            this.btnAddVenda.Click += new System.EventHandler(this.btnAddVenda_Click);
            // 
            // ExibirVendas
            // 
            this.ExibirVendas.Location = new System.Drawing.Point(187, 89);
            this.ExibirVendas.Name = "ExibirVendas";
            this.ExibirVendas.Size = new System.Drawing.Size(82, 48);
            this.ExibirVendas.TabIndex = 5;
            this.ExibirVendas.Text = "Exibir Vendas";
            this.ExibirVendas.UseVisualStyleBackColor = true;
            this.ExibirVendas.Click += new System.EventHandler(this.ExibirVendas_Click);
            // 
            // AddFornecedor
            // 
            this.AddFornecedor.Location = new System.Drawing.Point(187, 211);
            this.AddFornecedor.Name = "AddFornecedor";
            this.AddFornecedor.Size = new System.Drawing.Size(82, 48);
            this.AddFornecedor.TabIndex = 6;
            this.AddFornecedor.Text = "Adicionar Fornecedor";
            this.AddFornecedor.UseVisualStyleBackColor = true;
            this.AddFornecedor.Click += new System.EventHandler(this.AddFornecedor_Click);
            // 
            // AddCompra
            // 
            this.AddCompra.Location = new System.Drawing.Point(329, 35);
            this.AddCompra.Name = "AddCompra";
            this.AddCompra.Size = new System.Drawing.Size(82, 48);
            this.AddCompra.TabIndex = 7;
            this.AddCompra.Text = "Adicionar Compra";
            this.AddCompra.UseVisualStyleBackColor = true;
            this.AddCompra.Click += new System.EventHandler(this.AddCompra_Click);
            // 
            // ExibirFornecedores
            // 
            this.ExibirFornecedores.Location = new System.Drawing.Point(187, 265);
            this.ExibirFornecedores.Name = "ExibirFornecedores";
            this.ExibirFornecedores.Size = new System.Drawing.Size(82, 48);
            this.ExibirFornecedores.TabIndex = 8;
            this.ExibirFornecedores.Text = "Exibir Fornecedores";
            this.ExibirFornecedores.UseVisualStyleBackColor = true;
            this.ExibirFornecedores.Click += new System.EventHandler(this.ExibirFornecedores_Click);
            // 
            // ExibirCompras
            // 
            this.ExibirCompras.Location = new System.Drawing.Point(329, 89);
            this.ExibirCompras.Name = "ExibirCompras";
            this.ExibirCompras.Size = new System.Drawing.Size(82, 48);
            this.ExibirCompras.TabIndex = 10;
            this.ExibirCompras.Text = "Exibir Compras";
            this.ExibirCompras.UseVisualStyleBackColor = true;
            this.ExibirCompras.Click += new System.EventHandler(this.ExibirCompras_Click);
            // 
            // btnVerificarLucro
            // 
            this.btnVerificarLucro.Location = new System.Drawing.Point(329, 211);
            this.btnVerificarLucro.Name = "btnVerificarLucro";
            this.btnVerificarLucro.Size = new System.Drawing.Size(82, 48);
            this.btnVerificarLucro.TabIndex = 11;
            this.btnVerificarLucro.Text = "Verificar Lucro";
            this.btnVerificarLucro.UseVisualStyleBackColor = true;
            this.btnVerificarLucro.Click += new System.EventHandler(this.btnVerificarLucro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Produtos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Vendas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(166, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fornecedores";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Compras";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(341, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Lucro";
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(12, 342);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 21;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(452, 377);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerificarLucro);
            this.Controls.Add(this.ExibirCompras);
            this.Controls.Add(this.ExibirFornecedores);
            this.Controls.Add(this.AddCompra);
            this.Controls.Add(this.AddFornecedor);
            this.Controls.Add(this.ExibirVendas);
            this.Controls.Add(this.btnAddVenda);
            this.Controls.Add(this.ExibirClientes);
            this.Controls.Add(this.ExibirProdutos);
            this.Controls.Add(this.btnAddProduto);
            this.Controls.Add(this.btnAddCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddCliente;
        private System.Windows.Forms.Button btnAddProduto;
        private System.Windows.Forms.Button ExibirProdutos;
        private System.Windows.Forms.Button ExibirClientes;
        private System.Windows.Forms.Button btnAddVenda;
        private System.Windows.Forms.Button ExibirVendas;
        private System.Windows.Forms.Button AddFornecedor;
        private System.Windows.Forms.Button AddCompra;
        private System.Windows.Forms.Button ExibirFornecedores;
        private System.Windows.Forms.Button ExibirCompras;
        private System.Windows.Forms.Button btnVerificarLucro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSair;
    }
}

