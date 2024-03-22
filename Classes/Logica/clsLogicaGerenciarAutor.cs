using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    internal class clsLogicaGerenciarAutor : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Listar Todos Autores
        
        public List<clsModeloAutor> ListarAutores()
        {
            List<clsModeloAutor> listaAutores = new List<clsModeloAutor>();

            try
            {
                string nomeProcedure = "ListarAutores";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if(dados.HasRows)
                {
                    while(dados.Read())
                    {
                        clsModeloAutor autor = new clsModeloAutor(int.Parse(dados[0].ToString()));
                        listaAutores.Add(autor);
                    }
                }

                return listaAutores;
            }
            catch(Exception)
            {
                throw new Exception("Erro ao listar autores");
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

        #region Criar Autor

        public void CriarAutor(string nomeAutor)
        {
            try
            {
                string nomeProcedure = "CriarAutor";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vNome", nomeAutor));

                Executar(nomeProcedure, parametros);
            }
            catch(Exception)
            {
                throw new Exception("Erro ao criar autor");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Editar Autor

        public void EditarAutor(int codigoAutor, string nomeAutor)
        {
            try
            {
                string nomeProcedure = "EditarAutor";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoAutor.ToString()));
                parametros.Add(new clsModeloParametro("vNome", nomeAutor));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao editar autor");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion
    }
}
