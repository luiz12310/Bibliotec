using Gerenciador_biblioteca.Classes.Logica;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloTipoUsuario : ConexaoBanco
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        MySqlDataReader dados = null;

        public clsModeloTipoUsuario(int codigoTipoUser)
        {
            try
            {
                string nomeProcedure = "PreencherDadosTipoUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoTipoUser", codigoTipoUser.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Codigo = codigoTipoUser;
                        Nome = dados[0].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher tipo de usuário");
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
