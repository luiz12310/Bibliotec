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
    public class clsModeloAutor : ConexaoBanco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        MySqlDataReader dados = null;

        public clsModeloAutor(int codigoAutor)
        {
            try
            {
                string nomeProcedure = "PreencherAutor";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoAutor.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Codigo = codigoAutor;
                        Nome = dados[0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher autor");
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
