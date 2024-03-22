using Gerenciador_biblioteca.Classes.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Logica
{
    internal class clsLogicaGerenciarEditora : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Listar Todas Categorias

        public List<clsModeloEditora> ListarEditoras()
        {
            List<clsModeloEditora> listaEditoras = new List<clsModeloEditora>();

            try
            {
                string nomeProcedure = "ListarEditoras";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        clsModeloEditora editora = new clsModeloEditora(int.Parse(dados[0].ToString()));
                        listaEditoras.Add(editora);
                    }
                }

                return listaEditoras;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar editoras");
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

        #region Criar Editora

        public void CriarEditora(string nomeEditora)
        {
            try
            {
                string nomeProcedure = "CriarEditora";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vNome", nomeEditora));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao criar editora");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Editar Editora

        public void EditarEditora(int codigoEditora, string nomeEditora)
        {
            try
            {
                string nomeProcedure = "EditarEditora";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigo", codigoEditora.ToString()));
                parametros.Add(new clsModeloParametro("vNome", nomeEditora));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao editar editora");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion
    }
}
