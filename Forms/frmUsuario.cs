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
    public partial class frmUsuario : Form
    {
        public clsModeloUsuario Usuario { get; set; }
        clsLogicaGerenciarUsuario gerenciarUsuario = new clsLogicaGerenciarUsuario();
     
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        #region Limpar Dados

        public void LimparDados()
        {
            txtPesquisar.Text = "";

            try
            {
                dgvUsuarios.Rows.Clear();

                List<clsModeloUsuario> listaUsuarios = gerenciarUsuario.ListarUsuarios();
                foreach (clsModeloUsuario usuario in listaUsuarios)
                {
                    dgvUsuarios.Rows.Add(usuario.Nome, usuario.Login, usuario.Bloqueado);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Fechar Form

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Pesquisar Usuário

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PesquisarUsuario(txtPesquisar.Text);
        }

        public void PesquisarUsuario(string busca)
        {
            dgvUsuarios.Rows.Clear();

            try
            {

                if (String.IsNullOrEmpty(busca))
                {
                    try
                    {
                        List<clsModeloUsuario> listaUsuarios = gerenciarUsuario.ListarUsuarios();
                        foreach (clsModeloUsuario usuario in listaUsuarios)
                        {
                            dgvUsuarios.Rows.Add(usuario.Nome, usuario.Login, usuario.Bloqueado);
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
                        List<clsModeloUsuario> listaUsuarios = gerenciarUsuario.BuscarUsuario(busca);
                        foreach (clsModeloUsuario usuario in listaUsuarios)
                        {
                            dgvUsuarios.Rows.Add(usuario.Nome, usuario.Login, usuario.Bloqueado);
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Load Form

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                List<clsModeloUsuario> listaUsuarios = gerenciarUsuario.ListarUsuarios();
                foreach (clsModeloUsuario usuario in listaUsuarios)
                {
                    dgvUsuarios.Rows.Add(usuario.Nome, usuario.Login, usuario.Bloqueado);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region Identificar Usuário

        private void btnIdentificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.Rows.Count > 0)
                {
                    Usuario = new clsModeloUsuario(dgvUsuarios.Rows[dgvUsuarios.CurrentRow.Index].Cells[1].Value.ToString());
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro ao identificar usuário");
            }
        }

        #endregion
    }
}
