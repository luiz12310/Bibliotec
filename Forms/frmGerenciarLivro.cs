using Gerenciador_biblioteca.Classes.Logica;
using Gerenciador_biblioteca.Classes.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_biblioteca.Forms
{
    public partial class frmGerenciarLivro : Form
    {
        public clsModeloUsuario Usuario { get; set; }
        clsLogicaGerenciarLivro gerenciarLivro = new clsLogicaGerenciarLivro();
        clsLogicaGerenciarEmprestimo gerenciarEmprestimo = new clsLogicaGerenciarEmprestimo();

        public frmGerenciarLivro()
        {
            InitializeComponent();
        }

        private void frmGerenciarLivro_Load(object sender, EventArgs e)
        {

            CarregarDadosUsuario();
            ProcurarLivro("");
            
        }

        public void CarregarDadosUsuario()
        {
            if(lblNomeUsuario.Text == "Usuário: ")
            {
                lblNomeUsuario.Text = "Usuário: Sem usuário logado";
                lblLogin.Visible = false;
                lblBloqueado.Visible = false;
                lblDataBLoqueio.Visible = false;
                lblDataDesbloqueio.Visible = false;
            }
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            frmUsuario form = new frmUsuario();
            form.ShowDialog();

            if (form.Usuario != null)
            {
                lblLogin.Visible = true;
                lblBloqueado.Visible = true;
                lblDataBLoqueio.Visible = true;
                lblDataDesbloqueio.Visible = true;
                lblLivrosEmprestados.Visible = true;

                Usuario = form.Usuario;
                lblNomeUsuario.Text = "Usuário: " + form.Usuario.Nome;
                lblLogin.Text = "Login: " + form.Usuario.Login;

                if(!Usuario.Bloqueado)
                    lblBloqueado.Text = "Bloqueado: Não";
                else
                    lblBloqueado.Text = "Bloqueado: Sim";

                if (Usuario.DtBloqueio.ToString() == "01/01/0001 00:00:00")
                    lblDataBLoqueio.Text = "Usuário não bloqueado";
                else
                    lblDataBLoqueio.Text = "Data de Bloqueio: " + Usuario.DtBloqueio.ToString("dd/MM/yyyy");

                if (Usuario.DtDesbloqueio.ToString() == "01/01/0001 00:00:00")
                {
                    lblDataDesbloqueio.Text = "Usuário não bloqueado";
                    btnDesbloquear.Enabled = false;
                }
                else
                {
                    lblDataDesbloqueio.Text = "Data de Desbloqueio: " + Usuario.DtDesbloqueio.ToString("dd/MM/yyyy");
                    btnDesbloquear.Enabled = true;
                }

                int qtLivrosEmprestados = ContarEmprestimos();
                lblLivrosEmprestados.Text = "Livros Emprestados: " + qtLivrosEmprestados.ToString();

                if (!this.Usuario.Bloqueado)
                {
                    if (qtLivrosEmprestados > 2)
                    {
                        MessageBox.Show("Limite de empréstimos atingido.");

                        btnEmprestar.Enabled = false;
                    }
                    else
                    {
                        btnEmprestar.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Este usuário está bloqueado até dia " + this.Usuario.DtDesbloqueio.Day + "/" + this.Usuario.DtDesbloqueio.Month + "/" + this.Usuario.DtDesbloqueio.Year + ", portanto não pode realizar empréstimos, apenas devolver livros emprestados.");
                    
                    btnEmprestar.Enabled = false;
                }

                if(lblLivrosEmprestados.Text == "Livros Emprestados: 0")
                {
                    btnDevolverLivros.Enabled = false;
                }
                else
                {
                    btnDevolverLivros.Enabled = true;
                }
            
                btnDevolverLivros.Visible = true;
                btnSairUsuario.Visible = true;
                btnDesbloquear.Visible = true;
                btnLogar.Visible = false;
            }
        }

        #region Checar Quantidade Empréstimos

        public int ContarEmprestimos()
        {
            int contagemEmprestimos = gerenciarEmprestimo.ContarQuantidadeEmprestimos(this.Usuario.Login);

            return contagemEmprestimos;
        }

        #endregion

        #region Pesquisar Livro

        private void btnPesquisarLivro_Click(object sender, EventArgs e)
        {
            LimparDadosLivro();
            ProcurarLivro(txtPesquisa.Text);
        }

        public void ProcurarLivro(string busca)
        {
            dgvLivros.Rows.Clear();

            try
            {
                if(String.IsNullOrEmpty(busca))
                {
                    try
                    {
                        List<clsModeloLivro> listaLivros = gerenciarLivro.ListarTodosLivros();
                        foreach (clsModeloLivro livro in listaLivros)
                        {
                            string disponibilidade = gerenciarLivro.ListarDisponibilidade(livro.Codigo);
                            string listaAutores = "";

                            foreach(clsModeloAutor autor in livro.Autor)
                            {
                                listaAutores += autor.Nome + ", ";
                            }

                            listaAutores = listaAutores.Substring(0, listaAutores.Length - 2);

                            dgvLivros.Rows.Add(livro.Titulo, listaAutores, livro.Editora.Nome, disponibilidade, livro.Codigo);
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
                else
                {
                    try
                    {
                        List<clsModeloLivro> listaLivros = gerenciarLivro.PesquisarLivro(busca);
                        foreach (clsModeloLivro livro in listaLivros)
                        {
                            string disponibilidade = gerenciarLivro.ListarDisponibilidade(livro.Codigo); 
                            
                            string listaAutores = "";
                            foreach (clsModeloAutor autor in livro.Autor)
                            {
                                listaAutores += autor.Nome + ", ";
                            }

                            listaAutores = listaAutores.Substring(0, listaAutores.Length - 2);

                            dgvLivros.Rows.Add(livro.Titulo, listaAutores, livro.Editora.Nome, disponibilidade, livro.Codigo);
                        }
                    }
                    catch(Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Limpar Dados Livro

        public void LimparDadosLivro()
        {
            dgvLivros.Rows.Clear();

            txtTitulo.Text = "";
            txtEditora.Text = "";
            txtDisponibilidade.Text = "";
            txtAnoLancamento.Text = "";
            txtAutores.Text = "";
            txtISBN.Text = "";
            txtCategorias.Text = "";
            rtbSinopse.Text = "";
        }

        #endregion

        #region Detalhar Livro

        private void dgvLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvLivros.RowCount > 0)
                {
                    clsModeloLivro livro = new clsModeloLivro();

                    try
                    {

                        livro.DetalharLivro(int.Parse(dgvLivros.CurrentRow.Cells[4].Value.ToString()));

                        txtTitulo.Text = livro.Titulo;
                        txtISBN.Text = livro.ISBN;
                        txtEditora.Text = livro.Editora.Nome;
                        txtAnoLancamento.Text = livro.AnoLancamento.ToString();
                        txtDisponibilidade.Text = livro.Disponibilidade;

                        string listaCategorias = "";
                        foreach (clsModeloCategoria categoria in livro.Categoria)
                        {
                            listaCategorias += categoria.Nome + ", ";
                        }

                        listaCategorias = listaCategorias.Substring(0, listaCategorias.Length - 2);

                        txtCategorias.Text = listaCategorias;

                        string listaAutores = "";
                        foreach (clsModeloAutor autor in livro.Autor)
                        {
                            listaAutores += autor.Nome + ", ";
                        }

                        listaAutores = listaAutores.Substring(0, listaAutores.Length - 2);

                        txtAutores.Text = listaAutores;

                        if(livro.Sinopse == "")
                        {
                            rtbSinopse.Text = "Livro sem descrição";
                        }
                        else
                        {
                            rtbSinopse.Text = livro.Sinopse;                        
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Devolver Livros

        private void btnDevolverLivros_Click(object sender, EventArgs e)
        {
            try
            {
                frmCarrinho form = new frmCarrinho(this.Usuario);
                form.ShowDialog();

                if (!Usuario.Bloqueado)
                    lblBloqueado.Text = "Bloqueado: Não";
                else
                    lblBloqueado.Text = "Bloqueado: Sim";

                if (Usuario.DtBloqueio.ToString() == "01/01/0001 00:00:00")
                    lblDataBLoqueio.Text = "Usuário não bloqueado";
                else
                    lblDataBLoqueio.Text = "Data de Bloqueio: " + Usuario.DtBloqueio.ToString("dd/MM/yyyy");

                if (Usuario.DtDesbloqueio.ToString() == "01/01/0001 00:00:00")
                {
                    lblDataDesbloqueio.Text = "Usuário não bloqueado";
                    btnDesbloquear.Enabled = false;
                }
                else
                {
                    lblDataDesbloqueio.Text = "Data de Desbloqueio: " + Usuario.DtDesbloqueio.ToString("dd/MM/yyyy");
                    btnDesbloquear.Enabled = true;
                }

                int qtLivrosEmprestados = ContarEmprestimos();
                lblLivrosEmprestados.Text = "Livros Emprestados: " + qtLivrosEmprestados.ToString();

                if(lblLivrosEmprestados.Text == "Livros Emprestados: 0")
                    btnDevolverLivros.Enabled = false;

                dgvLivros.Rows.Clear();
                LimparDadosLivro();
            
                List<clsModeloLivro> listaLivros = gerenciarLivro.ListarTodosLivros();
                foreach (clsModeloLivro livro in listaLivros)
                {
                    string disponibilidade = gerenciarLivro.ListarDisponibilidade(livro.Codigo);

                    string listaAutores = "";
                    foreach (clsModeloAutor autor in livro.Autor)
                        listaAutores += autor.Nome + ", ";

                    listaAutores = listaAutores.Substring(0, listaAutores.Length - 2);

                    dgvLivros.Rows.Add(livro.Titulo, listaAutores, livro.Editora.Nome, disponibilidade, livro.Codigo);

                }

                if(Usuario.Bloqueado)
                {
                    MessageBox.Show("Usuário Bloqueado");
                    btnEmprestar.Enabled = false;
                }
                else
                {
                    if (lblLivrosEmprestados.Text != "Livros Emprestados: 3")
                        btnEmprestar.Enabled = true;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Emprestar Livro

        private void btnEmprestar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoLivro = int.Parse(dgvLivros.CurrentRow.Cells[4].Value.ToString());

                try
                {
                    if(!Usuario.Bloqueado)
                    {
                        try
                        {
                            gerenciarEmprestimo.RealizarEmprestimo(Usuario.Login, codigoLivro);
                            lblLivrosEmprestados.Text = "Livros Emprestados: " + ContarEmprestimos();
                            MessageBox.Show("Emprestimo realizado com sucesso");

                            if (lblLivrosEmprestados.Text != "Livros Emprestados: 0")
                                btnDevolverLivros.Enabled = true;
                            else
                                btnDevolverLivros.Enabled = false;

                            if (lblLivrosEmprestados.Text == "Livros Emprestados: 3")
                            {
                                btnEmprestar.Enabled = false;
                                MessageBox.Show("Limite de Empréstimos Realizados");
                            }
                            else
                                btnEmprestar.Enabled = true;

                            dgvLivros.Rows.Clear();

                            List<clsModeloLivro> listaLivros = gerenciarLivro.ListarTodosLivros();
                            foreach (clsModeloLivro livro in listaLivros)
                            {
                                string disponibilidade = gerenciarLivro.ListarDisponibilidade(livro.Codigo);

                                string listaAutores = "";
                                foreach (clsModeloAutor autor in livro.Autor)
                                {
                                    listaAutores += autor.Nome + ", ";
                                }

                                listaAutores = listaAutores.Substring(0, listaAutores.Length - 2);

                                dgvLivros.Rows.Add(livro.Titulo, listaAutores, livro.Editora.Nome, disponibilidade, livro.Codigo);
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este usuário não pode realizar empréstimo pois está bloqueado até " + Usuario.DtDesbloqueio.ToString());
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Sair Usuário

        private void btnSairUsuario_Click(object sender, EventArgs e)
        {
            this.Usuario = null;

            lblNomeUsuario.Text = "Usuário: ";
            lblLogin.Visible = false;
            lblDataBLoqueio.Visible = false;
            lblDataDesbloqueio.Visible = false;
            lblBloqueado.Visible = false;
            lblLivrosEmprestados.Visible = false;

            btnSairUsuario.Visible = false;
            btnDevolverLivros.Visible = false;
            btnLogar.Visible = true;
            btnDesbloquear.Visible = false;
            btnEmprestar.Enabled = false;

            frmGerenciarLivro_Load(sender, e);
        }

        #endregion

        #region Botão Desbloquear

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario.DesbloquearUsuario(Usuario.Login);
                this.Usuario = new clsModeloUsuario(Usuario.Login);                 

                lblDataBLoqueio.Text = "Usuário não bloqueado";
                lblDataDesbloqueio.Text = "Usuário não bloqueado";
                lblBloqueado.Text = "Bloqueado: não";

                MessageBox.Show("Usuário desbloqueado!");
                btnDesbloquear.Enabled = false;
                btnEmprestar.Enabled = true;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion
    }
}
