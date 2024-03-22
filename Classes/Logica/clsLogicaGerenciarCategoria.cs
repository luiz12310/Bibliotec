using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    internal class clsLogicaGerenciarCategoria : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Listar Todas Categorias

        public List<clsModeloCategoria> ListarCategorias()
        {
            List<clsModeloCategoria> listaCategorias = new List<clsModeloCategoria>();

            try
            {
                string nomeProcedure = "ListarCategorias";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloCategoria categoria = new clsModeloCategoria(int.Parse(dados[0].ToString()));
                        listaCategorias.Add(categoria);
                    }
                }

                return listaCategorias;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar categorias");
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

        #region Criar Categoria

        public void CriarCategoria(string nomeCategoria)
        {
            try
            {
                string nomeProcedure = "CriarCategoria";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vNome", nomeCategoria));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao criar categoria");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Editar Autor

        public void EditarCategoria(int codigoCategoria, string nomeCategoria)
        {
            try
            {
                string nomeProcedure = "EditarCategoria";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoCategoria.ToString()));
                parametros.Add(new clsModeloParametro("vNome", nomeCategoria));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao editar categoria");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion
    }
}
