using Gerenciador_biblioteca.Classes.Logica;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloCategoria : ConexaoBanco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }


        MySqlDataReader dados = null;

        public clsModeloCategoria(int codigoCategoria)
        {
            try
            {
                string nomeProcedure = "PreencherDadosCategoria";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoCategoria", codigoCategoria.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Codigo = codigoCategoria;
                        Nome = dados[0].ToString();
                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao preencher dados da categoria");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }
    }
}
