using Gerenciador_biblioteca.Classes.Logica;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloEmprestimo : ConexaoBanco
    {
        public int Codigo { get; set; }
        public clsModeloUsuario Usuario { get; set; }
        public clsModeloExemplar Exemplar { get; set; }
        public clsModeloLivro Livro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataEstimadaDevolucao { get; set; }

        MySqlDataReader dados = null;

        public clsModeloEmprestimo()
        {

        }

        public clsModeloEmprestimo(int codigo, string login, int codigoExemplar, int codigoLivro, DateTime dataEmprestimo, DateTime dataDevolucaoEstimada, DateTime dataDevolucaoReal)
        {
            Codigo = codigo;
            Usuario = new clsModeloUsuario(login);
            Exemplar = new clsModeloExemplar(codigoExemplar, codigoLivro);
            Livro = new clsModeloLivro(Exemplar.Livro.Codigo);
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucaoReal;
            DataEstimadaDevolucao = dataDevolucaoEstimada;
        }

        public clsModeloEmprestimo(string login, int codigoLivro, int codigoExemplar, int codigoEmprestimo)
        {
            try
            {
                string nomeProcedure = "PreencherEmprestimo";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();

                parametros.Add(new clsModeloParametro("vLogin", login));
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoExemplar", codigoExemplar.ToString()));
                parametros.Add(new clsModeloParametro("vCodigoEmprestimo", codigoEmprestimo.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if(dados.HasRows)
                {
                    while(dados.Read())
                    {
                        Codigo = codigoEmprestimo;
                        Usuario = new clsModeloUsuario(login);
                        Exemplar = new clsModeloExemplar(codigoExemplar, codigoLivro);
                        Livro = new clsModeloLivro(codigoLivro);

                        DataEmprestimo = DateTime.Parse(dados[0].ToString());
                        DataEstimadaDevolucao = DateTime.Parse(dados[1].ToString());
                        DataDevolucao = DateTime.Parse(dados[2].ToString());
                    }
                }
            }
            catch(Exception)
            {
                throw new Exception("Erro ao preencher dados do empréstimo");
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
