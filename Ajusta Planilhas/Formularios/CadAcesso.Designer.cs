namespace Gestao_Planilhas
{
    partial class CadAcesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadAcesso));
            label4 = new Label();
            label2 = new Label();
            bt_fechar = new Button();
            lb_Cab = new Label();
            tb_Senha = new TextBox();
            tb_Email = new TextBox();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            tb_nome = new TextBox();
            cb_Status = new ComboBox();
            cb_Perfil = new ComboBox();
            bt_Salvar = new Button();
            pn_Combos = new Panel();
            pn_Combos.SuspendLayout();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Roboto", 12F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(109, 171);
            label4.Name = "label4";
            label4.Size = new Size(54, 19);
            label4.TabIndex = 18;
            label4.Text = "Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 12F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(109, 117);
            label2.Name = "label2";
            label2.Size = new Size(53, 19);
            label2.TabIndex = 17;
            label2.Text = "E-mail";
            // 
            // bt_fechar
            // 
            bt_fechar.BackColor = Color.Transparent;
            bt_fechar.Cursor = Cursors.Hand;
            bt_fechar.FlatAppearance.BorderColor = Color.FromArgb(167, 165, 165);
            bt_fechar.FlatAppearance.BorderSize = 0;
            bt_fechar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bt_fechar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bt_fechar.FlatStyle = FlatStyle.Flat;
            bt_fechar.Image = Properties.Resources.fechar_24x24;
            bt_fechar.Location = new Point(452, 12);
            bt_fechar.Name = "bt_fechar";
            bt_fechar.Size = new Size(32, 30);
            bt_fechar.TabIndex = 16;
            bt_fechar.UseVisualStyleBackColor = false;
            bt_fechar.Click += bt_fechar_Click;
            // 
            // lb_Cab
            // 
            lb_Cab.AutoSize = true;
            lb_Cab.BackColor = Color.Transparent;
            lb_Cab.Font = new Font("Roboto", 20.25F);
            lb_Cab.ForeColor = SystemColors.ButtonHighlight;
            lb_Cab.Location = new Point(12, 9);
            lb_Cab.Name = "lb_Cab";
            lb_Cab.Size = new Size(229, 33);
            lb_Cab.TabIndex = 15;
            lb_Cab.Text = "Cadastrar Acesso";
            // 
            // tb_Senha
            // 
            tb_Senha.BackColor = Color.FromArgb(167, 165, 165);
            tb_Senha.BorderStyle = BorderStyle.None;
            tb_Senha.Font = new Font("Roboto", 12F);
            tb_Senha.Location = new Point(109, 192);
            tb_Senha.Name = "tb_Senha";
            tb_Senha.Size = new Size(290, 20);
            tb_Senha.TabIndex = 14;
            tb_Senha.UseSystemPasswordChar = true;
            // 
            // tb_Email
            // 
            tb_Email.BackColor = Color.FromArgb(167, 165, 165);
            tb_Email.BorderStyle = BorderStyle.None;
            tb_Email.CharacterCasing = CharacterCasing.Lower;
            tb_Email.Font = new Font("Roboto", 12F);
            tb_Email.Location = new Point(109, 138);
            tb_Email.Name = "tb_Email";
            tb_Email.Size = new Size(290, 20);
            tb_Email.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto", 12F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(109, 67);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 17;
            label1.Text = "Nome";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Roboto", 12F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(7, 5);
            label5.Name = "label5";
            label5.Size = new Size(55, 19);
            label5.TabIndex = 17;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Roboto", 12F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(189, 5);
            label6.Name = "label6";
            label6.Size = new Size(45, 19);
            label6.TabIndex = 17;
            label6.Text = "Perfil";
            // 
            // tb_nome
            // 
            tb_nome.BackColor = Color.FromArgb(167, 165, 165);
            tb_nome.BorderStyle = BorderStyle.None;
            tb_nome.Font = new Font("Roboto", 12F);
            tb_nome.Location = new Point(109, 87);
            tb_nome.Name = "tb_nome";
            tb_nome.Size = new Size(290, 20);
            tb_nome.TabIndex = 13;
            // 
            // cb_Status
            // 
            cb_Status.FlatStyle = FlatStyle.Flat;
            cb_Status.FormattingEnabled = true;
            cb_Status.Items.AddRange(new object[] { "Ativo", "Inativo" });
            cb_Status.Location = new Point(7, 27);
            cb_Status.Name = "cb_Status";
            cb_Status.Size = new Size(108, 22);
            cb_Status.TabIndex = 19;
            // 
            // cb_Perfil
            // 
            cb_Perfil.FlatStyle = FlatStyle.Flat;
            cb_Perfil.FormattingEnabled = true;
            cb_Perfil.Items.AddRange(new object[] { "Gestor" });
            cb_Perfil.Location = new Point(189, 27);
            cb_Perfil.Name = "cb_Perfil";
            cb_Perfil.Size = new Size(108, 22);
            cb_Perfil.TabIndex = 19;
            // 
            // bt_Salvar
            // 
            bt_Salvar.BackColor = Color.Transparent;
            bt_Salvar.FlatAppearance.BorderColor = Color.WhiteSmoke;
            bt_Salvar.FlatAppearance.MouseDownBackColor = Color.LightGray;
            bt_Salvar.FlatAppearance.MouseOverBackColor = Color.LightGray;
            bt_Salvar.FlatStyle = FlatStyle.Flat;
            bt_Salvar.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bt_Salvar.ForeColor = Color.WhiteSmoke;
            bt_Salvar.Location = new Point(214, 294);
            bt_Salvar.Name = "bt_Salvar";
            bt_Salvar.Size = new Size(81, 33);
            bt_Salvar.TabIndex = 20;
            bt_Salvar.Text = "Salvar";
            bt_Salvar.UseVisualStyleBackColor = false;
            bt_Salvar.Click += bt_Salvar_Click;
            // 
            // pn_Combos
            // 
            pn_Combos.BackColor = Color.Transparent;
            pn_Combos.Controls.Add(cb_Status);
            pn_Combos.Controls.Add(label5);
            pn_Combos.Controls.Add(cb_Perfil);
            pn_Combos.Controls.Add(label6);
            pn_Combos.Location = new Point(102, 218);
            pn_Combos.Name = "pn_Combos";
            pn_Combos.Size = new Size(304, 57);
            pn_Combos.TabIndex = 21;
            // 
            // CadAcesso
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fundo_512;
            ClientSize = new Size(496, 339);
            Controls.Add(pn_Combos);
            Controls.Add(bt_Salvar);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(bt_fechar);
            Controls.Add(lb_Cab);
            Controls.Add(tb_Senha);
            Controls.Add(tb_nome);
            Controls.Add(tb_Email);
            Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CadAcesso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadAcesso";
            Load += CadAcesso_Load;
            pn_Combos.ResumeLayout(false);
            pn_Combos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label2;
        private Button bt_fechar;
        private Label lb_Cab;
        private TextBox tb_Senha;
        private TextBox tb_Email;
        private Label label1;
        private Label label5;
        private Label label6;
        private TextBox tb_nome;
        private ComboBox cb_Status;
        private ComboBox cb_Perfil;
        private Button bt_Salvar;
        private Panel pn_Combos;
    }
}