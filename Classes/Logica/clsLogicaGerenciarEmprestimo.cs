using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    internal class clsLogicaGerenciarEmprestimo : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Devolver Livro

        public void DevolverLivro(string login, int codigoLivro, int codigoExemplar, int codigoEmprestimo)
        {
            try
            {
                string nomeProcedure = "DevolverLivro";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoExemplar", codigoExemplar.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoEmprestimo", codigoEmprestimo.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar devolver livro.");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Calcular Quantidade Empréstimos

        public int ContarQuantidadeEmprestimos(string login)
        {
            int quantidadeLivrosEmprestados = 0;

            try
            {
                string nomeProcedure = "ContarQuantidadeEmprestimos";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        quantidadeLivrosEmprestados++;
                    }
                }

                return quantidadeLivrosEmprestados;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao contar quantidade de empréstimos do cliente");
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

        #region Listar Empréstimos

        public List<clsModeloEmprestimo> ListarEmprestimos(string login)
        {
            List<clsModeloEmprestimo> listaEmprestimos = new List<clsModeloEmprestimo>();

            try
            {
                string nomeProcedure = "ListarEmprestimos";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloEmprestimo emprestimo = new clsModeloEmprestimo(int.Parse(dados[0].ToString()), dados[1].ToString(), int.Parse(dados[2].ToString()), int.Parse(dados[3].ToString()), DateTime.Parse(dados[4].ToString()), DateTime.Parse(dados[5].ToString()), DateTime.Parse(dados[6].ToString()));
                        listaEmprestimos.Add(emprestimo);
                    }
                }

                return listaEmprestimos;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar empréstimos.");
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

        #region Realizar Empréstimo

        public void RealizarEmprestimo(string login, int codigoLivro)
        {
            try
            {
                string nomeProcedure = "RealizarEmprestimo";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Não existe exemplar desse livro disponível");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion
    }
}
