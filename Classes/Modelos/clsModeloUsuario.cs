using Gerenciador_biblioteca.Classes.Logica;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloUsuario : ConexaoBanco
    {
        #region Propriedades

        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime DtBloqueio { get; set; }
        public DateTime DtDesbloqueio { get; set; }
        public clsModeloTipoUsuario TipoUsuario { get; set; }
        MySqlDataReader dados = null;

        #endregion

        public clsModeloUsuario()
        {

        }

        public clsModeloUsuario(string login)
        {
            try
            {
                string nomeProcedure = "PreencherDadosUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Login = login;
                        Nome = dados[0].ToString();
                        Senha = dados[1].ToString();
                        Bloqueado = bool.Parse(dados[2].ToString());
                        TipoUsuario = new clsModeloTipoUsuario(int.Parse(dados[3].ToString()));

                        if (Bloqueado)
                        {
                            DtBloqueio = DateTime.Parse(dados[4].ToString());
                            DtDesbloqueio = DateTime.Parse(dados[5].ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher dados do usuário");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }

        public void DesbloquearUsuario(string login)
        {
            try
            {
                string nomeProcedure = "DesbloquearUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                parametros.Add(new clsModeloParametro("vLogin", login));
                Executar(nomeProcedure, parametros);
            }
            catch(Exception)
            {
                throw new Exception("Erro ao desbloquear usuário");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
