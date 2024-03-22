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
    public partial class frmOcorrencia : Form
    {
        clsModeloUsuario Usuario = new clsModeloUsuario();
        clsModeloEmprestimo Emprestimo = new clsModeloEmprestimo();
        clsLogicaGerenciarOcorrencia gerenciarOcorrencia = new clsLogicaGerenciarOcorrencia();
        public bool Existe = false;

        public frmOcorrencia(clsModeloUsuario usuario, clsModeloEmprestimo emprestimo)
        {
            InitializeComponent();
            Usuario = usuario;
            Emprestimo = emprestimo;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtOcorrencia.Text))
                {
                    MessageBox.Show("Descreva a ocorrência.");
                    return;
                }

                if (cmbTipoOcorrencia.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o tipo da ocorrência.");
                    return;
                }

                gerenciarOcorrencia.EnviarOcorrencia(Usuario.Login, txtOcorrencia.Text, cmbTipoOcorrencia.SelectedItem.ToString(), Emprestimo.Exemplar.Codigo, Emprestimo.Livro.Codigo, Emprestimo.Codigo);
                MessageBox.Show("Ocorrência enviada com sucesso");

                Usuario.Bloqueado = true;
                Usuario.DtBloqueio = DateTime.Today;
                Usuario.DtDesbloqueio = DateTime.Today.AddDays(15);
                Existe = true;
                this.Close();

            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void frmOcorrencia_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> listaNomesOcorrencias = gerenciarOcorrencia.PreencherOcorrencias();
                foreach (string nomeOcorrencia in listaNomesOcorrencias)
                {
                    cmbTipoOcorrencia.Items.Add(nomeOcorrencia);
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
