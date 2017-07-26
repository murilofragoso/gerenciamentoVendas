using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CQ
{
    class Repository
    {
        SqlConnection conexao = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog = db_CQ ;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public int IDProduto;
        public int IDFornecedor;
        public int IDCliente;

        public void AdicionarCLiente(string nome, Int64 cnpj, string endereco, Int64 cep , Int64 tel, string email, Int64 ie)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("NovoCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cnpj",cnpj);
            comando.Parameters.AddWithValue("@endereco", endereco);
            comando.Parameters.AddWithValue("@cep", cep);
            comando.Parameters.AddWithValue("@tel",tel);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@ie", ie);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            Desconectar();
        }

        public void AdicionarProduto(string nome, decimal vpadrao,int estoque)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("NovoProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@vpadrao", vpadrao);
            comando.Parameters.AddWithValue("@estoque", estoque);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void AdicionarVenda(int quantidade,double desconto,DateTime data)
        {
            BuscarID();
            GridClientes clienteatual = new GridClientes();
            string cliente = clienteatual.RetornarCliente();
            GridProdutos produtoatual = new GridProdutos();
            string produto = produtoatual.RetornarProduto();
            Conectar();
            SqlCommand comando2 = new SqlCommand("NovaVenda", conexao);
            comando2.CommandType = CommandType.StoredProcedure;
            comando2.Parameters.AddWithValue("@NomeCliente", cliente);
            comando2.Parameters.AddWithValue("@NomeProduto", produto);
            comando2.Parameters.AddWithValue("@Quantidade",quantidade);
            comando2.Parameters.AddWithValue("@Desconto", desconto);
            comando2.Parameters.AddWithValue("@ID_Produto", IDProduto);
            comando2.Parameters.AddWithValue("data", data.ToShortDateString());
            try
            {
                comando2.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void AdicionarCompra(int quantidade,double valor,DateTime data)
        {
            BuscarID();
            BuscarIDFornecedor();
            Conectar();
            SqlCommand comando = new SqlCommand("NovaCompra", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@valorpago", valor);
            comando.Parameters.AddWithValue("@ID_Produto", IDProduto);
            comando.Parameters.AddWithValue("@ID_Fornecedor", IDFornecedor);
            comando.Parameters.AddWithValue("@data", data.ToShortDateString());
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void AdicionarFornecedor(string nome,Int64 CNPJ,string endereco, Int64 cep,Int64 tel,string email,Int64 ie)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("NovoFornecedor",conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@cnpj", CNPJ);
            comando.Parameters.AddWithValue("@endereco", endereco);
            comando.Parameters.AddWithValue("@cep", cep);
            comando.Parameters.AddWithValue("@tel", tel);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@ie", ie);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void BuscarID()
        {
            GridProdutos produtoatual = new GridProdutos();
            Conectar();
            SqlCommand comando = new SqlCommand("ReceberID", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomeproduto", produtoatual.RetornarProduto());
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                IDProduto = leitor.GetInt32(leitor.GetOrdinal("ID_Produto"));
            }
            Desconectar();
        }

        public void BuscarIDFornecedor()
        {
            GridFornecedores fornecedoratual = new GridFornecedores();
            Conectar();
            SqlCommand comando = new SqlCommand("ReceberIDFornecedor", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomeFornecedor", fornecedoratual.RetornarFornecedor());
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                IDFornecedor = leitor.GetInt32(leitor.GetOrdinal("ID_Fornecedor"));
            }
            Desconectar();
        }

        public void BuscarIDCliente()
        {
            GridClientes clienteatual = new GridClientes();
            Conectar();
            SqlCommand comando = new SqlCommand("ReceberIDCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nome", clienteatual.RetornarCliente());
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                IDCliente = leitor.GetInt32(leitor.GetOrdinal("ID_Cliente"));
            }
            Desconectar();
        }

        public void Conectar()
        {
            try
            {
                conexao.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Produto> PreencerProdutos()
        {
            Conectar();
            List<Produto> lista = new List<Produto>();
            SqlCommand comando = new SqlCommand("EnviarProdutos", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Produto produtoatual = new Produto(
                    leitor.GetString(leitor.GetOrdinal("Nome_Produto")),
                    leitor.GetDecimal(leitor.GetOrdinal("Valor_Padrao")),
                    leitor.GetInt32(leitor.GetOrdinal("Estoque")));
                lista.Add(produtoatual);
            }
            Desconectar();
            return lista;
        }

        public List<Cliente> PreencerClientes()
        {
            Conectar();
            List<Cliente> lista = new List<Cliente>();
            SqlCommand comando = new SqlCommand("EnviarClientes", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Cliente Clienteatual = new Cliente(
                    leitor.GetString(leitor.GetOrdinal("Nome_Cliente")),
                    leitor.GetString(leitor.GetOrdinal("Endereco_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("Tel_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("CEP_Cliente")),
                    leitor.GetString(leitor.GetOrdinal("Email_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("CNPJ_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("IE_Cliente")));
                lista.Add(Clienteatual);
            }
            Desconectar();
            return lista;
        }

        public List<Venda> PreencherVendas()
        {
            Conectar();
            List<Venda> lista = new List<Venda>();
            SqlCommand comando = new SqlCommand("EnviarVendas", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Venda vendaatual = new Venda(
                    leitor.GetString(leitor.GetOrdinal("Nome_Cliente")),
                    leitor.GetString(leitor.GetOrdinal("Nome_produto")),
                    leitor.GetInt32(leitor.GetOrdinal("Quantidade")),
                    leitor.GetDecimal(leitor.GetOrdinal("Desconto")),
                    leitor.GetDecimal(leitor.GetOrdinal("Total")),
                    leitor.GetDateTime(leitor.GetOrdinal("Data_Venda")));
                lista.Add(vendaatual);
            }
            Desconectar();
            return lista;
        }

        public List<Fornecedor> PreencherFornecedores()
        {
            Conectar();
            List<Fornecedor> lista = new List<Fornecedor>();
            SqlCommand comando = new SqlCommand("EnviarFornecedores", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Fornecedor fornecedoratual = new Fornecedor(
                    leitor.GetString(leitor.GetOrdinal("Nome_Fornecedor")),
                    leitor.GetInt64(leitor.GetOrdinal("CNPJ_Fornecedor")),
                    leitor.GetString(leitor.GetOrdinal("Endereco_Fornecedor")),
                    leitor.GetInt64(leitor.GetOrdinal("CEP_Fornecedor")),
                    leitor.GetInt64(leitor.GetOrdinal("Tel_Fornecedor")),
                    leitor.GetString(leitor.GetOrdinal("Email_Fornecedor")),
                    leitor.GetInt64(leitor.GetOrdinal("IE_Fornecedor"))
                    );
                lista.Add(fornecedoratual);
            }
            Desconectar();
            return lista;
        }

        public List<Compra> PreencherCompras()
        {
            Conectar();
            List<Compra> lista = new List<Compra>();
            SqlCommand comando = new SqlCommand("EnviarCompras",conexao);
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Compra compraatual = new Compra(
                    leitor.GetString(leitor.GetOrdinal("Nome_Fornecedor")),
                    leitor.GetString(leitor.GetOrdinal("Nome_Produto")),
                    leitor.GetInt32(leitor.GetOrdinal("Quantidade")),
                    leitor.GetDecimal(leitor.GetOrdinal("ValorPago")),
                    leitor.GetDateTime(leitor.GetOrdinal("Data_Compra"))
                    );
                lista.Add(compraatual);
            }
            Desconectar();
            return lista;
        }

        public void DecrementarEstoque(int quantidade)
        {
            BuscarID();
            Conectar();
            SqlCommand comando = new SqlCommand("DecrementarEstoque", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Quantidade", quantidade);
            comando.Parameters.AddWithValue("@ID_produto", IDProduto);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            Desconectar();
        }

        public void IncrementarEstoque(int quantidade)
        {
            BuscarID();
            Conectar();
            SqlCommand comando = new SqlCommand("IncrementarEstoque", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Quantidade", quantidade);
            comando.Parameters.AddWithValue("@ID_produto", IDProduto);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public string VerificarLucro(DateTime data1,DateTime data2)
        {
            decimal LucroTotal = 0;
            Conectar();
            SqlCommand comando = new SqlCommand("Lucro", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@data1", data1);
            comando.Parameters.AddWithValue("@data2", data2);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                LucroTotal = leitor.GetDecimal(leitor.GetOrdinal("TOTAL"));
            }
            int LucroTotalConvertido = Convert.ToInt32(LucroTotal);
            Desconectar();
            return LucroTotalConvertido.ToString();
        }

        public void ClearAllVendas()
        {
            Conectar();
            SqlCommand comando = new SqlCommand("ClearAllVendas",conexao);
            comando.CommandType = CommandType.StoredProcedure;
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void ClearAllCompras()
        {
            Conectar();
            SqlCommand comando = new SqlCommand("ClearAllCompras", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void ClearParteVendas(DateTime data1,DateTime data2)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("ClearParteVendas", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@data1", data1.ToShortDateString());
            comando.Parameters.AddWithValue("@data2", data2.ToShortDateString());
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void ClearParteCompras(DateTime data1,DateTime data2)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("ClearParteCompras", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@data1", data1.ToShortDateString());
            comando.Parameters.AddWithValue("@data2", data2.ToShortDateString());
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void ClearCLiente()
        {
            BuscarIDCliente();
            Conectar();
            SqlCommand comando = new SqlCommand("ClearCLiente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Cliente", IDCliente);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                if(MessageBox.Show("Existem dados vinculados a este cliente, deseja excluir todos os dados ?",
                    "Dados vinculados",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Desconectar();
                    ClearDadosCliente();
                }
            }
            Desconectar();
        }

        public void ClearDadosCliente()
        {
            BuscarIDCliente();
            Conectar();
            SqlCommand comando = new SqlCommand("ClearDadosCLiente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Cliente", IDCliente);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void ClearFornecedor()
        {
            BuscarIDFornecedor();
            Conectar();
            SqlCommand comando = new SqlCommand("ClearFornecedor", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Fornecedor", IDFornecedor);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                if(MessageBox.Show("Existem dados vinculados a este fornecedor, deseja excluir todos os dados ?") == DialogResult.Yes)
                {
                    Desconectar();
                    ClearDadosFornecedor();
                }
            }
            Desconectar();
        }

        public void ClearDadosFornecedor()
        {
            BuscarIDFornecedor();
            Conectar();
            SqlCommand comando = new SqlCommand("ClearDadosFornecedor", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Fornecedor", IDFornecedor);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public void ClearProduto()
        {
            BuscarID();
            Conectar();
            SqlCommand comando = new SqlCommand("ClearProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Produto", IDProduto);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public List<Fornecedor> PesquisarFornecedores(string nome)
        {
            List<Fornecedor> lista = new List<Fornecedor>();
            Conectar();
            SqlCommand comando = new SqlCommand("PesquisarFornecedores", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@palavra", nome);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Fornecedor fornecedoratual = new Fornecedor(
                           leitor.GetString(leitor.GetOrdinal("Nome_Fornecedor")),
                           leitor.GetInt64(leitor.GetOrdinal("CNPJ_Fornecedor")),
                           leitor.GetString(leitor.GetOrdinal("Endereco_Fornecedor")),
                           leitor.GetInt64(leitor.GetOrdinal("CEP_Fornecedor")),
                           leitor.GetInt64(leitor.GetOrdinal("Tel_Fornecedor")),
                           leitor.GetString(leitor.GetOrdinal("Email_Fornecedor")),
                           leitor.GetInt64(leitor.GetOrdinal("IE_Fornecedor"))
                           );
                            lista.Add(fornecedoratual);
            }
            Desconectar();
            return lista;
        }

        public List<Compra> PesquisarFornecedoresCompras(string nome)
        {
            Conectar();
            List<Compra> lista = new List<Compra>();
            SqlCommand comando = new SqlCommand("PesquisarFornecedoresCompras", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@palavra", nome);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Compra compraatual = new Compra(
                    leitor.GetString(leitor.GetOrdinal("Nome_Fornecedor")),
                    leitor.GetString(leitor.GetOrdinal("Nome_Produto")),
                    leitor.GetInt32(leitor.GetOrdinal("Quantidade")),
                    leitor.GetDecimal(leitor.GetOrdinal("ValorPago")),
                    leitor.GetDateTime(leitor.GetOrdinal("Data_Compra"))
                    );
                lista.Add(compraatual);
            }
            Desconectar();
            return lista;
        }


        public List<Cliente> PesquisarClientes(string nome)
        {
            Conectar();
            List<Cliente> lista = new List<Cliente>();
            SqlCommand comando = new SqlCommand("PesquisarClientes", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@palavra", nome);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Cliente Clienteatual = new Cliente(
                    leitor.GetString(leitor.GetOrdinal("Nome_Cliente")),
                    leitor.GetString(leitor.GetOrdinal("Endereco_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("Tel_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("CEP_Cliente")),
                    leitor.GetString(leitor.GetOrdinal("Email_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("CNPJ_Cliente")),
                    leitor.GetInt64(leitor.GetOrdinal("IE_Cliente")));
                lista.Add(Clienteatual);
            }
            Desconectar();
            return lista;
        }

        public List<Venda> PesquisarClienteVendas(string nome)
        {
            Conectar();
            List<Venda> lista = new List<Venda>();
            SqlCommand comando = new SqlCommand("PesquisarClientesVendas", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@palavra", nome);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Venda vendaatual = new Venda(
                    leitor.GetString(leitor.GetOrdinal("Nome_Cliente")),
                    leitor.GetString(leitor.GetOrdinal("Nome_produto")),
                    leitor.GetInt32(leitor.GetOrdinal("Quantidade")),
                    leitor.GetDecimal(leitor.GetOrdinal("Desconto")),
                    leitor.GetDecimal(leitor.GetOrdinal("Total")),
                    leitor.GetDateTime(leitor.GetOrdinal("Data_Venda")));
                lista.Add(vendaatual);
            }
            Desconectar();
            return lista;
        }

        public List<Produto> PesquisarProdutos(string nome)
        {
            Conectar();
            List<Produto> lista = new List<Produto>();
            SqlCommand comando = new SqlCommand("PesquisarProdutos", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@palavra", nome);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Produto produtoatual = new Produto(
                    leitor.GetString(leitor.GetOrdinal("Nome_Produto")),
                    leitor.GetDecimal(leitor.GetOrdinal("Valor_Padrao")),
                    leitor.GetInt32(leitor.GetOrdinal("Estoque")));
                lista.Add(produtoatual);
            }
            Desconectar();
            return lista;
        }

        public List<Venda> PesquisarDataVendas(DateTime data1, DateTime data2)
        {
            List<Venda> lista = new List<Venda>();
            Conectar();
            SqlCommand comando = new SqlCommand("PesquisarDataVendas", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@data1", data1);
            comando.Parameters.AddWithValue("@data2", data2);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Venda vendaatual = new Venda(
                       leitor.GetString(leitor.GetOrdinal("Nome_Cliente")),
                       leitor.GetString(leitor.GetOrdinal("Nome_produto")),
                       leitor.GetInt32(leitor.GetOrdinal("Quantidade")),
                       leitor.GetDecimal(leitor.GetOrdinal("Desconto")),
                       leitor.GetDecimal(leitor.GetOrdinal("Total")),
                       leitor.GetDateTime(leitor.GetOrdinal("Data_Venda")));
                lista.Add(vendaatual);
            }
            Desconectar();
            return lista;
        }

        public List<Compra> PesquisarDataCompras(DateTime data1,DateTime data2)
        {
            Conectar();
            List<Compra> lista = new List<Compra>();
            SqlCommand comando = new SqlCommand("PesquisarDataCompras", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@data1",data1);
            comando.Parameters.AddWithValue("@data2", data2);
            SqlDataReader leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                Compra compraatual = new Compra(
                    leitor.GetString(leitor.GetOrdinal("Nome_Fornecedor")),
                    leitor.GetString(leitor.GetOrdinal("Nome_Produto")),
                    leitor.GetInt32(leitor.GetOrdinal("Quantidade")),
                    leitor.GetDecimal(leitor.GetOrdinal("ValorPago")),
                    leitor.GetDateTime(leitor.GetOrdinal("Data_Compra"))
                    );
                lista.Add(compraatual);
            }
            Desconectar();
            return lista;
        }

        public void UpdateProduto(decimal vpadrao, int estoque)
        {
            BuscarID();
            Conectar();
            SqlCommand comando = new SqlCommand("UpdateProduto", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Produto",IDProduto);
            comando.Parameters.AddWithValue("@vpadrao", vpadrao);
            comando.Parameters.AddWithValue("@estoque", estoque);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }
        public void UpdateCLiente(Int64 cnpj, string endereco, Int64 cep, Int64 tel, string email, Int64 ie)
        {
            BuscarIDCliente();
            Conectar();
            SqlCommand comando = new SqlCommand("UpdateCliente", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Cliente", IDCliente);
            comando.Parameters.AddWithValue("@cnpj", cnpj);
            comando.Parameters.AddWithValue("@endereco", endereco);
            comando.Parameters.AddWithValue("@cep", cep);
            comando.Parameters.AddWithValue("@tel", tel);
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@ie", ie);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            Desconectar();
        }

        public void UpdateFornecedor(Int64 CNPJ, string endereco, Int64 cep, Int64 tel, string email, Int64 ie)
        {
            BuscarIDFornecedor();
            Conectar();
            SqlCommand comando = new SqlCommand("UpdateFornecedor", conexao);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID_Fornecedor",IDFornecedor);
            comando.Parameters.AddWithValue("@cnpj", CNPJ);
            comando.Parameters.AddWithValue("@endereco", endereco);
            comando.Parameters.AddWithValue("@cep", cep);
            comando.Parameters.AddWithValue("@tel", tel);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@ie", ie);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            Desconectar();
        }

        public void Desconectar()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
