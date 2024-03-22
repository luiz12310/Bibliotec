using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    internal class clsLogicaGerenciarLivro : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Listar Todos Livros

        public List<clsModeloLivro> ListarTodosLivros()
        {
            List<clsModeloLivro> listaLivros = new List<clsModeloLivro>();

            try
            {
                string nomeProcedure = "ListarTodosLivros";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloLivro livro = new clsModeloLivro(int.Parse(dados[0].ToString()));
                        listaLivros.Add(livro);
                    }
                }

                return listaLivros;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar livros");
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

        #region Pesquisar Livro

        public List<clsModeloLivro> PesquisarLivro(string nomeLivro)
        {
            List<clsModeloLivro> listaLivros = new List<clsModeloLivro>();

            try
            {
                string nomeProcedure = "PesquisarLivro";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vPesquisar", nomeLivro.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloLivro livro = new clsModeloLivro(int.Parse(dados[0].ToString()));
                        listaLivros.Add(livro);
                    }
                }

                return listaLivros;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao pesquisar livro");
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

        #region Listar Disponobilidade

        public string ListarDisponibilidade(int codigoLivro)
        {
            string disponibilidade = "";

            try
            {
                string nomeProcedure = "ListarDisponibilidade";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        disponibilidade = dados[0].ToString() + "/" + dados[1].ToString();
                    }
                }

                return disponibilidade;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar livros disponíveis");
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

        #region Criar Livro

        public void CriarLivro(string titulo, string ISBN)
        {
            try
            {
                string nomeProcedure = "CriarLivro";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                Executar(nomeProcedure, parametros);
            }
            catch(Exception)
            {
                throw new Exception("Erro ao criar livro");
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
    }
}
