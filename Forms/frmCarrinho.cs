using Gerenciador_biblioteca.Classes.Logica;
using Gerenciador_biblioteca.Classes.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_biblioteca.Forms
{
    public partial class frmCarrinho : Form
    {
        public clsModeloUsuario Usuario { get; set; }
        clsLogicaGerenciarEmprestimo gerenciarEmprestimo = new clsLogicaGerenciarEmprestimo();
        public frmCarrinho(clsModeloUsuario usuario)
        {
            InitializeComponent();
            Usuario = usuario;
        }

        #region Load

        public void CarregarEmprestimos()
        {
            try
            {
                dgvEmprestimos.Rows.Clear();
                List<clsModeloEmprestimo> listaEmprestimos = gerenciarEmprestimo.ListarEmprestimos(Usuario.Login);
                foreach (clsModeloEmprestimo emprestimo in listaEmprestimos)
                {
                    dgvEmprestimos.Rows.Add(emprestimo.Livro.Titulo, emprestimo.DataEmprestimo.ToString("dd/MM/yyyy"), emprestimo.DataEstimadaDevolucao.ToString("dd/MM/yyyy"), "Devolver", emprestimo.Exemplar.Codigo, emprestimo.Livro.Codigo, emprestimo.Codigo);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void frmCarrinho_Load(object sender, EventArgs e)
        {
            CarregarEmprestimos();
        }

        #endregion

        #region Fechar

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Devolver Livro

        private void dgvEmprestimos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object valorCelula = dgvEmprestimos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (valorCelula == dgvEmprestimos.Rows[dgvEmprestimos.CurrentRow.Index].Cells[3].Value)
                {
                    try
                    {
                        int codigoExemplar = int.Parse(dgvEmprestimos.CurrentRow.Cells[4].Value.ToString());
                        int codigoLivro = int.Parse(dgvEmprestimos.CurrentRow.Cells[5].Value.ToString());
                        int codigoEmprestimo = int.Parse(dgvEmprestimos.CurrentRow.Cells[6].Value.ToString());

                        clsModeloEmprestimo emprestimo = new clsModeloEmprestimo(Usuario.Login, codigoLivro, codigoExemplar, codigoEmprestimo);

                        frmOcorrencia form = new frmOcorrencia(Usuario, emprestimo);
                        if (MessageBox.Show("Há algum defeito no livro devolvido?", "Registrar ocorrência", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            form.ShowDialog();

                            if(form.Existe)
                            {
                                gerenciarEmprestimo.DevolverLivro(Usuario.Login, emprestimo.Livro.Codigo, emprestimo.Exemplar.Codigo, emprestimo.Codigo);
                                MessageBox.Show("Livro devolvido com sucesso.");
                                dgvEmprestimos.Rows.Clear();
                                CarregarEmprestimos();

                                if (dgvEmprestimos.Rows.Count <= 0)
                                    this.Close();
                            }
                        }
                        else
                        {
                            gerenciarEmprestimo.DevolverLivro(Usuario.Login, emprestimo.Livro.Codigo, emprestimo.Exemplar.Codigo, emprestimo.Codigo);
                            MessageBox.Show("Livro devolvido com sucesso.");
                            dgvEmprestimos.Rows.Clear();
                            CarregarEmprestimos();

                            if (dgvEmprestimos.Rows.Count <= 0)
                                this.Close();
                        }
                    }
                    catch(Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
        }

        #endregion
    }
}