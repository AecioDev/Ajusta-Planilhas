namespace Gestao_Planilhas
{
    partial class Acesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acesso));
            tb_Usuario = new TextBox();
            tb_Senha = new TextBox();
            bt_Login = new Button();
            label3 = new Label();
            bt_fechar = new Button();
            lb_RecSenha = new Label();
            label2 = new Label();
            label4 = new Label();
            cb_Lembrar = new CheckBox();
            tb_Rodape = new TextBox();
            lb_NovoAcesso = new Label();
            SuspendLayout();
            // 
            // tb_Usuario
            // 
            tb_Usuario.BackColor = Color.FromArgb(167, 165, 165);
            tb_Usuario.BorderStyle = BorderStyle.None;
            tb_Usuario.CharacterCasing = CharacterCasing.Lower;
            tb_Usuario.Font = new Font("Roboto", 12F);
            tb_Usuario.Location = new Point(129, 204);
            tb_Usuario.Name = "tb_Usuario";
            tb_Usuario.Size = new Size(254, 20);
            tb_Usuario.TabIndex = 0;
            // 
            // tb_Senha
            // 
            tb_Senha.BackColor = Color.FromArgb(167, 165, 165);
            tb_Senha.BorderStyle = BorderStyle.None;
            tb_Senha.CharacterCasing = CharacterCasing.Lower;
            tb_Senha.Font = new Font("Roboto", 12F);
            tb_Senha.Location = new Point(129, 278);
            tb_Senha.Name = "tb_Senha";
            tb_Senha.Size = new Size(254, 20);
            tb_Senha.TabIndex = 1;
            tb_Senha.UseSystemPasswordChar = true;
            // 
            // bt_Login
            // 
            bt_Login.BackColor = Color.Transparent;
            bt_Login.Cursor = Cursors.Hand;
            bt_Login.FlatAppearance.BorderColor = Color.FromArgb(167, 165, 165);
            bt_Login.FlatAppearance.BorderSize = 0;
            bt_Login.FlatAppearance.MouseDownBackColor = Color.Transparent;
            bt_Login.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bt_Login.FlatStyle = FlatStyle.Flat;
            bt_Login.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            bt_Login.ForeColor = Color.WhiteSmoke;
            bt_Login.Image = Properties.Resources.bt_Login;
            bt_Login.Location = new Point(167, 329);
            bt_Login.Name = "bt_Login";
            bt_Login.Size = new Size(179, 40);
            bt_Login.TabIndex = 5;
            bt_Login.UseCompatibleTextRendering = true;
            bt_Login.UseVisualStyleBackColor = false;
            bt_Login.Click += bt_Login_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Roboto", 20.25F);
            label3.Location = new Point(204, 138);
            label3.Name = "label3";
            label3.Size = new Size(104, 33);
            label3.TabIndex = 6;
            label3.Text = "Acesso";
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
            bt_fechar.Location = new Point(468, 12);
            bt_fechar.Name = "bt_fechar";
            bt_fechar.Size = new Size(32, 32);
            bt_fechar.TabIndex = 7;
            bt_fechar.UseVisualStyleBackColor = false;
            bt_fechar.Click += bt_fechar_Click;
            // 
            // lb_RecSenha
            // 
            lb_RecSenha.AutoSize = true;
            lb_RecSenha.BackColor = Color.Transparent;
            lb_RecSenha.Cursor = Cursors.Hand;
            lb_RecSenha.Font = new Font("Roboto", 8.25F);
            lb_RecSenha.Location = new Point(222, 389);
            lb_RecSenha.Name = "lb_RecSenha";
            lb_RecSenha.Size = new Size(92, 13);
            lb_RecSenha.TabIndex = 10;
            lb_RecSenha.Text = "Recuperar Senha";
            lb_RecSenha.TextAlign = ContentAlignment.MiddleRight;
            lb_RecSenha.Click += lb_RecSenha_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 12F);
            label2.Location = new Point(125, 175);
            label2.Name = "label2";
            label2.Size = new Size(53, 19);
            label2.TabIndex = 11;
            label2.Text = "E-mail";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Roboto", 12F);
            label4.Location = new Point(125, 248);
            label4.Name = "label4";
            label4.Size = new Size(54, 19);
            label4.TabIndex = 12;
            label4.Text = "Senha";
            // 
            // cb_Lembrar
            // 
            cb_Lembrar.AutoSize = true;
            cb_Lembrar.BackColor = Color.Transparent;
            cb_Lembrar.Cursor = Cursors.Hand;
            cb_Lembrar.FlatAppearance.BorderSize = 0;
            cb_Lembrar.FlatStyle = FlatStyle.Flat;
            cb_Lembrar.Font = new Font("Roboto", 8.25F);
            cb_Lembrar.Location = new Point(120, 387);
            cb_Lembrar.Name = "cb_Lembrar";
            cb_Lembrar.Size = new Size(96, 17);
            cb_Lembrar.TabIndex = 13;
            cb_Lembrar.Text = "Gravar Acesso";
            cb_Lembrar.UseVisualStyleBackColor = false;
            // 
            // tb_Rodape
            // 
            tb_Rodape.BackColor = Color.FromArgb(167, 165, 165);
            tb_Rodape.BorderStyle = BorderStyle.None;
            tb_Rodape.Font = new Font("Roboto Condensed", 9F);
            tb_Rodape.ForeColor = Color.DarkRed;
            tb_Rodape.Location = new Point(127, 309);
            tb_Rodape.Name = "tb_Rodape";
            tb_Rodape.Size = new Size(258, 15);
            tb_Rodape.TabIndex = 14;
            tb_Rodape.Text = "Bem Vindo !!!";
            tb_Rodape.TextAlign = HorizontalAlignment.Right;
            // 
            // lb_NovoAcesso
            // 
            lb_NovoAcesso.AutoSize = true;
            lb_NovoAcesso.BackColor = Color.Transparent;
            lb_NovoAcesso.Cursor = Cursors.Hand;
            lb_NovoAcesso.Font = new Font("Roboto", 8.25F);
            lb_NovoAcesso.Location = new Point(320, 389);
            lb_NovoAcesso.Name = "lb_NovoAcesso";
            lb_NovoAcesso.Size = new Size(72, 13);
            lb_NovoAcesso.TabIndex = 10;
            lb_NovoAcesso.Text = "Novo Acesso";
            lb_NovoAcesso.TextAlign = ContentAlignment.MiddleRight;
            lb_NovoAcesso.Click += lb_NovoAcesso_Click;
            // 
            // Acesso
            // 
            AcceptButton = bt_Login;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImage = Properties.Resources.FundoAcesso;
            ClientSize = new Size(512, 512);
            Controls.Add(tb_Rodape);
            Controls.Add(cb_Lembrar);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lb_NovoAcesso);
            Controls.Add(lb_RecSenha);
            Controls.Add(bt_fechar);
            Controls.Add(label3);
            Controls.Add(bt_Login);
            Controls.Add(tb_Senha);
            Controls.Add(tb_Usuario);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Acesso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acesso";
            Load += Acesso_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tb_Usuario;
        private TextBox tb_Senha;
        private Button bt_Login;
        private Label label3;
        private Button bt_fechar;
        private Label lb_RecSenha;
        private Label label2;
        private Label label4;
        private CheckBox cb_Lembrar;
        private TextBox tb_Rodape;
        private Label lb_NovoAcesso;
    }
}