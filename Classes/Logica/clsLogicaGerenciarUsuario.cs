using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    internal class clsLogicaGerenciarUsuario : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Acessar Sistema

        public bool AcessarSistema(string login, string senha)
        {
            bool retorno = false;
            try
            {
                string nomeProcedure = "AcessarSistemaComputador";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));
                parametros.Add(new clsModeloParametro("vSenha", senha));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        retorno = true;
                    }
                }

                return retorno;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar entrar no sistema");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }

        #endregion

        #region Listar Usuários

        public List<clsModeloUsuario> ListarUsuarios()
        {
            List<clsModeloUsuario> listaUsuarios = new List<clsModeloUsuario>();

            try
            {
                string nomeProcedure = "ListarUsuarios";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloUsuario usuario = new clsModeloUsuario(dados[0].ToString());
                        listaUsuarios.Add(usuario);
                    }
                }

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar usuários");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }

        #endregion

        #region Listar Usuários Bloqueados

        public List<clsModeloUsuario> ListarUsuariosBloqueados()
        {
            List<clsModeloUsuario> listaUsuarios = new List<clsModeloUsuario>();

            try
            {
                string nomeProcedure = "ListarUsuariosBloqueados";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloUsuario usuario = new clsModeloUsuario(dados[0].ToString());
                        listaUsuarios.Add(usuario);
                    }
                }

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar usuários");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }
        }

        #endregion

        #region Buscar Usuários

        public List<clsModeloUsuario> BuscarUsuario(string nomeUsuario)
        {
            List<clsModeloUsuario> listaUsuarios = new List<clsModeloUsuario>();
            try
            {
                string nomeProcedure = "BuscarUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vPesquisa", nomeUsuario));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloUsuario usuario = new clsModeloUsuario(dados[0].ToString());
                        listaUsuarios.Add(usuario);
                    }
                }

                return listaUsuarios;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao pesquisar usuário");
            }
            finally
            {
                if (dados != null)
                    if (!dados.IsClosed)
                        dados.Close();
                Desconectar();
            }

        }

        #endregion

        #region Editar Usuário

        public void EditarUsuario(string loginUsuario, string nomeUsuario, string senhaUsuario)
        {
            try
            {
                string nomeProcedure = "EditarUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", loginUsuario));
                parametros.Add(new clsModeloParametro("vNome", nomeUsuario));
                parametros.Add(new clsModeloParametro("vSenha", senhaUsuario));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao editar usuário");
            }
            finally
            {
                Desconectar();
            }

        }

        #endregion

        #region Criar Usuário

        public void CriarUsuario(string loginUsuario, string nomeUsuario, string senhaUsuario)
        {
            try
            {
                string nomeProcedure = "CriarUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", loginUsuario));
                parametros.Add(new clsModeloParametro("vNome", nomeUsuario));
                parametros.Add(new clsModeloParametro("vSenha", senhaUsuario));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao criar usuário");
            }
            finally
            {
                Desconectar();
            }

        }

        #endregion
    }
}
