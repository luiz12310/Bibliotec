using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    public class ConexaoBanco
    {
        private string linhaConexao { get; set; }
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;

        public ConexaoBanco(string host, string user, string senha, string db)
        {
            linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Bibliotec";
        }

        public ConexaoBanco()
        {
            linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Bibliotec";
        }

        public void Conectar()
        {
            try
            {
                conexao = new MySqlConnection(linhaConexao);
                conexao.Open();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar do Banco de Dados");
            }
        }

        public void Desconectar()
        {
            try
            {
                if (conexao != null)
                {
                    if (conexao.State == System.Data.ConnectionState.Open)
                        conexao.Close();
                }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível se desconectar do Banco de Dados");
            }
        }

        public MySqlDataReader Pesquisar(string nomeProcedure, List<clsModeloParametro> parametros)
        {
            try
            {
                Conectar();

                cSQL = new MySqlCommand(nomeProcedure, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();

                for (int i = 0; parametros.Count > i; i++)
                {
                    cSQL.Parameters.AddWithValue(parametros[i].Nome, parametros[i].Valor.ToString());
                }

                return cSQL.ExecuteReader();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Consultar comando");
            }
        }

        public void Executar(string nomeProcedure, List<clsModeloParametro> parametros)
        {
            try
            {
                Conectar();

                cSQL = new MySqlCommand(nomeProcedure, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();

                for (int i = 0; parametros.Count > i; i++)
                {
                    cSQL.Parameters.AddWithValue(parametros[i].Nome, parametros[i].Valor.ToString());
                }

                cSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao executar comando");
            }
        }
    }
}