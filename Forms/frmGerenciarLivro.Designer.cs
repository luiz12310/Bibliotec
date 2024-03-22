namespace Gerenciador_biblioteca.Forms
{
    partial class frmGerenciarLivro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbLivro = new System.Windows.Forms.GroupBox();
            this.btnEmprestar = new System.Windows.Forms.Button();
            this.txtCategorias = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPesquisarLivro = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbSinopse = new System.Windows.Forms.RichTextBox();
            this.txtDisponibilidade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAutores = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEditora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnoLancamento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLivros = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbUsuario = new System.Windows.Forms.GroupBox();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btnDevolverLivros = new System.Windows.Forms.Button();
            this.lblLivrosEmprestados = new System.Windows.Forms.Label();
            this.lblDataDesbloqueio = new System.Windows.Forms.Label();
            this.lblDataBLoqueio = new System.Windows.Forms.Label();
            this.lblBloqueado = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnSairUsuario = new System.Windows.Forms.Button();
            this.btnLogar = new System.Windows.Forms.Button();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.grbLivro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).BeginInit();
            this.grbUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLivro
            // 
            this.grbLivro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLivro.Controls.Add(this.btnEmprestar);
            this.grbLivro.Controls.Add(this.txtCategorias);
            this.grbLivro.Controls.Add(this.label9);
            this.grbLivro.Controls.Add(this.txtISBN);
            this.grbLivro.Controls.Add(this.label8);
            this.grbLivro.Controls.Add(this.btnPesquisarLivro);
            this.grbLivro.Controls.Add(this.txtPesquisa);
            this.grbLivro.Controls.Add(this.label7);
            this.grbLivro.Controls.Add(this.label6);
            this.grbLivro.Controls.Add(this.rtbSinopse);
            this.grbLivro.Controls.Add(this.txtDisponibilidade);
            this.grbLivro.Controls.Add(this.label5);
            this.grbLivro.Controls.Add(this.txtAutores);
            this.grbLivro.Controls.Add(this.label4);
            this.grbLivro.Controls.Add(this.txtEditora);
            this.grbLivro.Controls.Add(this.label3);
            this.grbLivro.Controls.Add(this.txtAnoLancamento);
            this.grbLivro.Controls.Add(this.label2);
            this.grbLivro.Controls.Add(this.txtTitulo);
            this.grbLivro.Controls.Add(this.label1);
            this.grbLivro.Controls.Add(this.dgvLivros);
            this.grbLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.grbLivro.Location = new System.Drawing.Point(30, 158);
            this.grbLivro.Name = "grbLivro";
            this.grbLivro.Size = new System.Drawing.Size(951, 559);
            this.grbLivro.TabIndex = 1;
            this.grbLivro.TabStop = false;
            this.grbLivro.Text = "Dados Livro";
            // 
            // btnEmprestar
            // 
            this.btnEmprestar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmprestar.Enabled = false;
            this.btnEmprestar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnEmprestar.Location = new System.Drawing.Point(800, 493);
            this.btnEmprestar.Name = "btnEmprestar";
            this.btnEmprestar.Size = new System.Drawing.Size(105, 30);
            this.btnEmprestar.TabIndex = 20;
            this.btnEmprestar.Text = "Emprestar";
            this.btnEmprestar.UseVisualStyleBackColor = true;
            this.btnEmprestar.Click += new System.EventHandler(this.btnEmprestar_Click);
            // 
            // txtCategorias
            // 
            this.txtCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtCategorias.Location = new System.Drawing.Point(375, 333);
            this.txtCategorias.Name = "txtCategorias";
            this.txtCategorias.ReadOnly = true;
            this.txtCategorias.Size = new System.Drawing.Size(38, 23);
            this.txtCategorias.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label9.Location = new System.Drawing.Point(269, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Categorias: ";
            // 
            // txtISBN
            // 
            this.txtISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtISBN.Location = new System.Drawing.Point(87, 333);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.Size = new System.Drawing.Size(176, 23);
            this.txtISBN.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label8.Location = new System.Drawing.Point(29, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "ISBN: ";
            // 
            // btnPesquisarLivro
            // 
            this.btnPesquisarLivro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisarLivro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnPesquisarLivro.Location = new System.Drawing.Point(794, 43);
            this.btnPesquisarLivro.Name = "btnPesquisarLivro";
            this.btnPesquisarLivro.Size = new System.Drawing.Size(105, 30);
            this.btnPesquisarLivro.TabIndex = 15;
            this.btnPesquisarLivro.Text = "Buscar";
            this.btnPesquisarLivro.UseVisualStyleBackColor = true;
            this.btnPesquisarLivro.Click += new System.EventHandler(this.btnPesquisarLivro_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtPesquisa.Location = new System.Drawing.Point(124, 43);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(644, 23);
            this.txtPesquisa.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label7.Location = new System.Drawing.Point(29, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pesquisar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(29, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sinopse:";
            // 
            // rtbSinopse
            // 
            this.rtbSinopse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSinopse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.rtbSinopse.Location = new System.Drawing.Point(109, 380);
            this.rtbSinopse.Name = "rtbSinopse";
            this.rtbSinopse.ReadOnly = true;
            this.rtbSinopse.Size = new System.Drawing.Size(542, 143);
            this.rtbSinopse.TabIndex = 11;
            this.rtbSinopse.Text = "";
            // 
            // txtDisponibilidade
            // 
            this.txtDisponibilidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisponibilidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtDisponibilidade.Location = new System.Drawing.Point(787, 290);
            this.txtDisponibilidade.Name = "txtDisponibilidade";
            this.txtDisponibilidade.ReadOnly = true;
            this.txtDisponibilidade.Size = new System.Drawing.Size(112, 23);
            this.txtDisponibilidade.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(653, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Disponibilidade:";
            // 
            // txtAutores
            // 
            this.txtAutores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAutores.Location = new System.Drawing.Point(861, 328);
            this.txtAutores.Name = "txtAutores";
            this.txtAutores.ReadOnly = true;
            this.txtAutores.Size = new System.Drawing.Size(38, 23);
            this.txtAutores.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(781, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Autor(s):";
            // 
            // txtEditora
            // 
            this.txtEditora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditora.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtEditora.Location = new System.Drawing.Point(444, 292);
            this.txtEditora.Name = "txtEditora";
            this.txtEditora.ReadOnly = true;
            this.txtEditora.Size = new System.Drawing.Size(172, 23);
            this.txtEditora.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.Location = new System.Drawing.Point(371, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Editora:";
            // 
            // txtAnoLancamento
            // 
            this.txtAnoLancamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnoLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtAnoLancamento.Location = new System.Drawing.Point(824, 374);
            this.txtAnoLancamento.Name = "txtAnoLancamento";
            this.txtAnoLancamento.ReadOnly = true;
            this.txtAnoLancamento.Size = new System.Drawing.Size(81, 23);
            this.txtAnoLancamento.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(678, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ano Lançamento:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtTitulo.Location = new System.Drawing.Point(87, 292);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.ReadOnly = true;
            this.txtTitulo.Size = new System.Drawing.Size(246, 23);
            this.txtTitulo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(26, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Título:";
            // 
            // dgvLivros
            // 
            this.dgvLivros.AllowUserToAddRows = false;
            this.dgvLivros.AllowUserToDeleteRows = false;
            this.dgvLivros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvLivros.Location = new System.Drawing.Point(26, 79);
            this.dgvLivros.Name = "dgvLivros";
            this.dgvLivros.ReadOnly = true;
            this.dgvLivros.Size = new System.Drawing.Size(873, 183);
            this.dgvLivros.TabIndex = 0;
            this.dgvLivros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivros_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Título";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Autores";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Editora";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Disponibilidade";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Código";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // grbUsuario
            // 
            this.grbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbUsuario.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grbUsuario.Controls.Add(this.btnDesbloquear);
            this.grbUsuario.Controls.Add(this.btnDevolverLivros);
            this.grbUsuario.Controls.Add(this.lblLivrosEmprestados);
            this.grbUsuario.Controls.Add(this.lblDataDesbloqueio);
            this.grbUsuario.Controls.Add(this.lblDataBLoqueio);
            this.grbUsuario.Controls.Add(this.lblBloqueado);
            this.grbUsuario.Controls.Add(this.lblLogin);
            this.grbUsuario.Controls.Add(this.btnSairUsuario);
            this.grbUsuario.Controls.Add(this.btnLogar);
            this.grbUsuario.Controls.Add(this.lblNomeUsuario);
            this.grbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.grbUsuario.Location = new System.Drawing.Point(30, 29);
            this.grbUsuario.Name = "grbUsuario";
            this.grbUsuario.Size = new System.Drawing.Size(951, 123);
            this.grbUsuario.TabIndex = 0;
            this.grbUsuario.TabStop = false;
            this.grbUsuario.Text = "Dados Usuário";
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesbloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnDesbloquear.Location = new System.Drawing.Point(798, 66);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(105, 30);
            this.btnDesbloquear.TabIndex = 21;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Visible = false;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // btnDevolverLivros
            // 
            this.btnDevolverLivros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDevolverLivros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnDevolverLivros.Location = new System.Drawing.Point(687, 30);
            this.btnDevolverLivros.Name = "btnDevolverLivros";
            this.btnDevolverLivros.Size = new System.Drawing.Size(105, 30);
            this.btnDevolverLivros.TabIndex = 8;
            this.btnDevolverLivros.Text = "Devolver";
            this.btnDevolverLivros.UseVisualStyleBackColor = true;
            this.btnDevolverLivros.Visible = false;
            this.btnDevolverLivros.Click += new System.EventHandler(this.btnDevolverLivros_Click);
            // 
            // lblLivrosEmprestados
            // 
            this.lblLivrosEmprestados.AutoSize = true;
            this.lblLivrosEmprestados.Location = new System.Drawing.Point(472, 63);
            this.lblLivrosEmprestados.Name = "lblLivrosEmprestados";
            this.lblLivrosEmprestados.Size = new System.Drawing.Size(137, 17);
            this.lblLivrosEmprestados.TabIndex = 7;
            this.lblLivrosEmprestados.Text = "Livros Emprestados:";
            this.lblLivrosEmprestados.Visible = false;
            // 
            // lblDataDesbloqueio
            // 
            this.lblDataDesbloqueio.AutoSize = true;
            this.lblDataDesbloqueio.Location = new System.Drawing.Point(472, 37);
            this.lblDataDesbloqueio.Name = "lblDataDesbloqueio";
            this.lblDataDesbloqueio.Size = new System.Drawing.Size(149, 17);
            this.lblDataDesbloqueio.TabIndex = 6;
            this.lblDataDesbloqueio.Text = "Data de Desbloqueio: ";
            // 
            // lblDataBLoqueio
            // 
            this.lblDataBLoqueio.AutoSize = true;
            this.lblDataBLoqueio.Location = new System.Drawing.Point(245, 63);
            this.lblDataBLoqueio.Name = "lblDataBLoqueio";
            this.lblDataBLoqueio.Size = new System.Drawing.Size(125, 17);
            this.lblDataBLoqueio.TabIndex = 5;
            this.lblDataBLoqueio.Text = "Data de Bloqueio: ";
            // 
            // lblBloqueado
            // 
            this.lblBloqueado.AutoSize = true;
            this.lblBloqueado.Location = new System.Drawing.Point(38, 63);
            this.lblBloqueado.Name = "lblBloqueado";
            this.lblBloqueado.Size = new System.Drawing.Size(84, 17);
            this.lblBloqueado.TabIndex = 4;
            this.lblBloqueado.Text = "Bloqueado: ";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(245, 37);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(51, 17);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login: ";
            // 
            // btnSairUsuario
            // 
            this.btnSairUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSairUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSairUsuario.Location = new System.Drawing.Point(798, 30);
            this.btnSairUsuario.Name = "btnSairUsuario";
            this.btnSairUsuario.Size = new System.Drawing.Size(105, 30);
            this.btnSairUsuario.TabIndex = 2;
            this.btnSairUsuario.Text = "Sair";
            this.btnSairUsuario.UseVisualStyleBackColor = true;
            this.btnSairUsuario.Visible = false;
            this.btnSairUsuario.Click += new System.EventHandler(this.btnSairUsuario_Click);
            // 
            // btnLogar
            // 
            this.btnLogar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnLogar.Location = new System.Drawing.Point(798, 30);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(105, 30);
            this.btnLogar.TabIndex = 1;
            this.btnLogar.Text = "Logar Usuário";
            this.btnLogar.UseVisualStyleBackColor = true;
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Location = new System.Drawing.Point(38, 37);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(65, 17);
            this.lblNomeUsuario.TabIndex = 0;
            this.lblNomeUsuario.Text = "Usuário: ";
            // 
            // frmGerenciarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.grbLivro);
            this.Controls.Add(this.grbUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGerenciarLivro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Livro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGerenciarLivro_Load);
            this.grbLivro.ResumeLayout(false);
            this.grbLivro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivros)).EndInit();
            this.grbUsuario.ResumeLayout(false);
            this.grbUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbUsuario;
        private System.Windows.Forms.GroupBox grbLivro;
        private System.Windows.Forms.TextBox txtEditora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnoLancamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLivros;
        private System.Windows.Forms.Button btnSairUsuario;
        private System.Windows.Forms.Button btnLogar;
        private System.Windows.Forms.Label lblNomeUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbSinopse;
        private System.Windows.Forms.TextBox txtDisponibilidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAutores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPesquisarLivro;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDataBLoqueio;
        private System.Windows.Forms.Label lblBloqueado;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblDataDesbloqueio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtCategorias;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLivrosEmprestados;
        private System.Windows.Forms.Button btnDevolverLivros;
        private System.Windows.Forms.Button btnEmprestar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnDesbloquear;
    }
}