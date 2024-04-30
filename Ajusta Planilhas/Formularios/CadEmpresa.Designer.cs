namespace Gestao_Planilhas
{
    partial class CadEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadEmpresa));
            label1 = new Label();
            tb_nomeEmp = new TextBox();
            tb_pastapdrao = new TextBox();
            pb_LogoEmp = new PictureBox();
            bt_pastapdrao = new Button();
            lb_Empresa = new Label();
            bt_fechar = new Button();
            bt_Salvar = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_LogoEmp).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto", 12F);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(168, 66);
            label1.Name = "label1";
            label1.Size = new Size(139, 19);
            label1.TabIndex = 0;
            label1.Text = "Nome da Empresa";
            // 
            // tb_nomeEmp
            // 
            tb_nomeEmp.BackColor = Color.FromArgb(167, 165, 165);
            tb_nomeEmp.BorderStyle = BorderStyle.None;
            tb_nomeEmp.Font = new Font("Roboto", 12F);
            tb_nomeEmp.Location = new Point(168, 88);
            tb_nomeEmp.Name = "tb_nomeEmp";
            tb_nomeEmp.Size = new Size(335, 20);
            tb_nomeEmp.TabIndex = 0;
            // 
            // tb_pastapdrao
            // 
            tb_pastapdrao.BackColor = Color.FromArgb(167, 165, 165);
            tb_pastapdrao.BorderStyle = BorderStyle.None;
            tb_pastapdrao.Font = new Font("Roboto", 12F);
            tb_pastapdrao.Location = new Point(168, 145);
            tb_pastapdrao.Name = "tb_pastapdrao";
            tb_pastapdrao.Size = new Size(304, 20);
            tb_pastapdrao.TabIndex = 1;
            // 
            // pb_LogoEmp
            // 
            pb_LogoEmp.Image = Properties.Resources.Clique_Logo;
            pb_LogoEmp.InitialImage = Properties.Resources.Clique_Logo;
            pb_LogoEmp.Location = new Point(12, 51);
            pb_LogoEmp.Name = "pb_LogoEmp";
            pb_LogoEmp.Size = new Size(150, 150);
            pb_LogoEmp.TabIndex = 2;
            pb_LogoEmp.TabStop = false;
            pb_LogoEmp.Click += pb_LogoEmp_Click;
            // 
            // bt_pastapdrao
            // 
            bt_pastapdrao.Location = new Point(478, 144);
            bt_pastapdrao.Name = "bt_pastapdrao";
            bt_pastapdrao.Size = new Size(25, 23);
            bt_pastapdrao.TabIndex = 2;
            bt_pastapdrao.Text = "...";
            bt_pastapdrao.UseVisualStyleBackColor = true;
            bt_pastapdrao.Click += bt_pastapdrao_Click;
            // 
            // lb_Empresa
            // 
            lb_Empresa.AutoSize = true;
            lb_Empresa.BackColor = Color.Transparent;
            lb_Empresa.Font = new Font("Roboto", 20.25F);
            lb_Empresa.ForeColor = Color.WhiteSmoke;
            lb_Empresa.Location = new Point(12, 11);
            lb_Empresa.Name = "lb_Empresa";
            lb_Empresa.Size = new Size(246, 33);
            lb_Empresa.TabIndex = 17;
            lb_Empresa.Text = "Cadastrar Empresa";
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
            bt_fechar.TabIndex = 18;
            bt_fechar.UseVisualStyleBackColor = false;
            bt_fechar.Click += bt_fechar_Click;
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
            bt_Salvar.Location = new Point(422, 183);
            bt_Salvar.Name = "bt_Salvar";
            bt_Salvar.Size = new Size(81, 33);
            bt_Salvar.TabIndex = 3;
            bt_Salvar.Text = "Salvar";
            bt_Salvar.UseVisualStyleBackColor = false;
            bt_Salvar.Click += bt_Salvar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 12F);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(168, 123);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 20;
            label2.Text = "Pasta Padrão";
            // 
            // CadEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fundo_512;
            ClientSize = new Size(512, 228);
            Controls.Add(tb_nomeEmp);
            Controls.Add(tb_pastapdrao);
            Controls.Add(label2);
            Controls.Add(bt_Salvar);
            Controls.Add(bt_fechar);
            Controls.Add(lb_Empresa);
            Controls.Add(bt_pastapdrao);
            Controls.Add(pb_LogoEmp);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CadEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastra Empresa";
            ((System.ComponentModel.ISupportInitialize)pb_LogoEmp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_nomeEmp;
        private TextBox tb_pastapdrao;
        private PictureBox pb_LogoEmp;
        private Button bt_pastapdrao;
        private Label lb_Empresa;
        private Button bt_fechar;
        private Button bt_Salvar;
        private Label label2;
    }
}