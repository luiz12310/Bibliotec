using Gerenciador_biblioteca.Classes.Logica;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloLivro : ConexaoBanco
    {
        #region Propriedades

        public int Codigo { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int AnoLancamento { get; set; }
        public string Sinopse { get; set; }
        public clsModeloEditora Editora { get; set; }
        public List<clsModeloAutor> Autor { get; set; }
        public List<clsModeloCategoria> Categoria { get; set; }
        public string Disponibilidade { get; set; }

        MySqlDataReader dados = null;

        clsLogicaGerenciarLivro gerenciarLivro = new clsLogicaGerenciarLivro();

        #endregion

        #region Constructors

        public clsModeloLivro()
        {

        }

        public clsModeloLivro(int codigoLivro)
        {
            try
            {
                string nomeProcedure = "PreencherDadosLivro";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Codigo = codigoLivro;
                        Titulo = dados[0].ToString();
                        ISBN = dados[1].ToString();
                        AnoLancamento = int.Parse(dados[2].ToString());
                        Sinopse = dados[3].ToString();
                        Editora = new clsModeloEditora(int.Parse(dados[4].ToString()));

                        char[] cha = { ',' };
                        string[] arrayNumeros = dados[5].ToString().Split(cha);

                        Categoria = new List<clsModeloCategoria>();

                        for (int i = 0; i < arrayNumeros.Length; i++)
                        {
                            clsModeloCategoria categoria = new clsModeloCategoria(int.Parse(arrayNumeros[i]));
                            Categoria.Add(categoria);
                        }

                        string[] arrayAutores = dados[6].ToString().Split(cha);

                        Autor = new List<clsModeloAutor>();

                        for (int i = 0; i < arrayAutores.Length; i++)
                        {
                            clsModeloAutor autor = new clsModeloAutor(int.Parse(arrayAutores[i]));
                            Autor.Add(autor);
                        }

                        Disponibilidade = gerenciarLivro.ListarDisponibilidade(codigoLivro);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao preencher dados do livro");
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

        #region Detalhar Livro

        public void DetalharLivro(int codigoLivro)
        {

            try
            {
                string nomeProcedure = "DetalharLivro";
                List<clsModeloParametro> parametros = new List<clsModeloParametro>();
                parametros.Add(new clsModeloParametro("vCodigoLivro", codigoLivro.ToString()));

                dados = Pesquisar(nomeProcedure, parametros);

                if (dados.HasRows)
                {
                    while (dados.Read())
                    {
                        Titulo = dados[0].ToString();
                        ISBN = dados[1].ToString();
                        Editora = new clsModeloEditora(int.Parse(dados[2].ToString()));
                        AnoLancamento = int.Parse(dados[3].ToString());
                        Disponibilidade = dados[4].ToString() + "/" + dados[5].ToString();

                        char[] cha = { ',' };
                        string[] arrayNumeros = dados[6].ToString().Split(cha);

                        Categoria = new List<clsModeloCategoria>();

                        for (int i = 0; i < arrayNumeros.Length; i++)
                        {
                            clsModeloCategoria categoria = new clsModeloCategoria(int.Parse(arrayNumeros[i]));
                            Categoria.Add(categoria);
                        }

                        string[] arrayAutores = dados[7].ToString().Split(cha);

                        Autor = new List<clsModeloAutor>();

                        for (int i = 0; i < arrayAutores.Length; i++)
                        {
                            clsModeloAutor autor = new clsModeloAutor(int.Parse(arrayAutores[i]));
                            Autor.Add(autor);
                        }

                        Sinopse = dados[8].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro ao detalhar livro");
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
