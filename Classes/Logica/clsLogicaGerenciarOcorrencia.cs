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
    internal class clsLogicaGerenciarOcorrencia : ConexaoBanco
    {
        MySqlDataReader dados = null;

        #region Preencher CMB Ocorrências

        public List<string> PreencherOcorrencias()
        {
            List<string> listaNomes = new List<string>();
            string nomeOcorrencia = "";

            try
            {
                string nomeProcedure = "PreencherOcorrencias";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        nomeOcorrencia = dados[0].ToString();
                        listaNomes.Add(nomeOcorrencia);
                    }
                }

                return listaNomes;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao carregar ocorrências");
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

        #region Enviar Ocorrência

        public void EnviarOcorrencia(string login, string descricaoOcorrencia, string tipoOcorrencia, int codigoExemplar, int codigoLivro, int codigoEmprestimo)
        {
            try
            {
                string nomeProcedure = "EnviarOcorrencia";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));
                parametros.Add(new clsModeloParametro("vDescricao", descricaoOcorrencia));
                parametros.Add(new clsModeloParametro("vNomeTipoOcorrencia", tipoOcorrencia));
                parametros.Add(new clsModeloParametro("vCodigoExemplar", codigoExemplar.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoEmprestimo", codigoEmprestimo.ToString()));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao enviar ocorrência");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion

        #region Desbloquear Usuário

        public void DesbloquearUsuario(string login)
        {
            try
            {
                string nomeProcedure = "DesbloquearUsuario";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vLogin", login));

                Executar(nomeProcedure, parametros);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao desbloquear usuário");
            }
            finally
            {
                Desconectar();
            }
        }

        #endregion
    }
}
