namespace Ajusta_Planilhas
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            tb_resultado = new TextBox();
            bt_executar = new Button();
            label2 = new Label();
            label1 = new Label();
            bt_pastapadrao = new Button();
            tb_pastapdrao = new TextBox();
            cb_opcao = new ComboBox();
            ct_Tabs = new TabControl();
            tab_0 = new TabPage();
            tb_NovoNome = new TextBox();
            lb_NovoNome = new Label();
            bt_ExecPlanilha = new Button();
            rb_Ativar = new RadioButton();
            rb_Desativar = new RadioButton();
            rb_Eliminar = new RadioButton();
            rb_Renomear = new RadioButton();
            ct_ListaPlanilhas = new CheckedListBox();
            tab_1 = new TabPage();
            checkBox1 = new CheckBox();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label3 = new Label();
            tab_2 = new TabPage();
            ct_Tabs.SuspendLayout();
            tab_0.SuspendLayout();
            tab_1.SuspendLayout();
            SuspendLayout();
            // 
            // tb_resultado
            // 
            tb_resultado.BackColor = SystemColors.Control;
            tb_resultado.BorderStyle = BorderStyle.None;
            tb_resultado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tb_resultado.ForeColor = SystemColors.MenuHighlight;
            tb_resultado.Location = new Point(12, 241);
            tb_resultado.Name = "tb_resultado";
            tb_resultado.ReadOnly = true;
            tb_resultado.Size = new Size(413, 22);
            tb_resultado.TabIndex = 14;
            tb_resultado.Text = "Planilhas Geradas com Sucesso !!!";
            tb_resultado.TextAlign = HorizontalAlignment.Center;
            // 
            // bt_executar
            // 
            bt_executar.Location = new Point(153, 91);
            bt_executar.Name = "bt_executar";
            bt_executar.Size = new Size(98, 23);
            bt_executar.TabIndex = 13;
            bt_executar.Text = "03 - Executar";
            bt_executar.UseVisualStyleBackColor = true;
            bt_executar.Click += bt_executar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(231, 15);
            label2.TabIndex = 12;
            label2.Text = "01 - Selecione a Pasta Padrão das Planilhas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 62);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 11;
            label1.Text = "02 - Escolha uma Ação";
            // 
            // bt_pastapadrao
            // 
            bt_pastapadrao.Location = new Point(391, 27);
            bt_pastapadrao.Name = "bt_pastapadrao";
            bt_pastapadrao.Size = new Size(34, 23);
            bt_pastapadrao.TabIndex = 10;
            bt_pastapadrao.Text = "...";
            bt_pastapadrao.UseVisualStyleBackColor = true;
            bt_pastapadrao.Click += bt_pastapadrao_Click;
            // 
            // tb_pastapdrao
            // 
            tb_pastapdrao.Location = new Point(12, 27);
            tb_pastapdrao.Name = "tb_pastapdrao";
            tb_pastapdrao.Size = new Size(373, 23);
            tb_pastapdrao.TabIndex = 9;
            // 
            // cb_opcao
            // 
            cb_opcao.FormattingEnabled = true;
            cb_opcao.Items.AddRange(new object[] { "Criar Nova Planilha", "Alterar Planilha" });
            cb_opcao.Location = new Point(153, 58);
            cb_opcao.Name = "cb_opcao";
            cb_opcao.Size = new Size(272, 23);
            cb_opcao.TabIndex = 8;
            // 
            // ct_Tabs
            // 
            ct_Tabs.Controls.Add(tab_0);
            ct_Tabs.Controls.Add(tab_1);
            ct_Tabs.Controls.Add(tab_2);
            ct_Tabs.Location = new Point(13, 87);
            ct_Tabs.Name = "ct_Tabs";
            ct_Tabs.SelectedIndex = 0;
            ct_Tabs.Size = new Size(413, 148);
            ct_Tabs.TabIndex = 15;
            // 
            // tab_0
            // 
            tab_0.Controls.Add(tb_NovoNome);
            tab_0.Controls.Add(lb_NovoNome);
            tab_0.Controls.Add(bt_ExecPlanilha);
            tab_0.Controls.Add(rb_Ativar);
            tab_0.Controls.Add(rb_Desativar);
            tab_0.Controls.Add(rb_Eliminar);
            tab_0.Controls.Add(rb_Renomear);
            tab_0.Controls.Add(ct_ListaPlanilhas);
            tab_0.Location = new Point(4, 24);
            tab_0.Name = "tab_0";
            tab_0.Padding = new Padding(3);
            tab_0.Size = new Size(405, 120);
            tab_0.TabIndex = 2;
            tab_0.Text = "Planilhas na Pasta";
            tab_0.UseVisualStyleBackColor = true;
            // 
            // tb_NovoNome
            // 
            tb_NovoNome.CharacterCasing = CharacterCasing.Upper;
            tb_NovoNome.Location = new Point(306, 59);
            tb_NovoNome.Name = "tb_NovoNome";
            tb_NovoNome.Size = new Size(93, 23);
            tb_NovoNome.TabIndex = 16;
            tb_NovoNome.Visible = false;
            // 
            // lb_NovoNome
            // 
            lb_NovoNome.AutoSize = true;
            lb_NovoNome.Location = new Point(232, 62);
            lb_NovoNome.Name = "lb_NovoNome";
            lb_NovoNome.Size = new Size(72, 15);
            lb_NovoNome.TabIndex = 15;
            lb_NovoNome.Text = "Novo Nome";
            lb_NovoNome.Visible = false;
            // 
            // bt_ExecPlanilha
            // 
            bt_ExecPlanilha.Location = new Point(270, 86);
            bt_ExecPlanilha.Name = "bt_ExecPlanilha";
            bt_ExecPlanilha.Size = new Size(98, 23);
            bt_ExecPlanilha.TabIndex = 14;
            bt_ExecPlanilha.Text = "03 - Executar";
            bt_ExecPlanilha.UseVisualStyleBackColor = true;
            bt_ExecPlanilha.Click += bt_ExecPlanilha_Click;
            // 
            // rb_Ativar
            // 
            rb_Ativar.AutoSize = true;
            rb_Ativar.Location = new Point(316, 40);
            rb_Ativar.Name = "rb_Ativar";
            rb_Ativar.Size = new Size(56, 19);
            rb_Ativar.TabIndex = 1;
            rb_Ativar.TabStop = true;
            rb_Ativar.Text = "Ativar";
            rb_Ativar.UseVisualStyleBackColor = true;
            // 
            // rb_Desativar
            // 
            rb_Desativar.AutoSize = true;
            rb_Desativar.Location = new Point(316, 15);
            rb_Desativar.Name = "rb_Desativar";
            rb_Desativar.Size = new Size(73, 19);
            rb_Desativar.TabIndex = 1;
            rb_Desativar.TabStop = true;
            rb_Desativar.Text = "Desativar";
            rb_Desativar.UseVisualStyleBackColor = true;
            // 
            // rb_Eliminar
            // 
            rb_Eliminar.AutoSize = true;
            rb_Eliminar.Location = new Point(232, 40);
            rb_Eliminar.Name = "rb_Eliminar";
            rb_Eliminar.Size = new Size(68, 19);
            rb_Eliminar.TabIndex = 1;
            rb_Eliminar.TabStop = true;
            rb_Eliminar.Text = "Eliminar";
            rb_Eliminar.UseVisualStyleBackColor = true;
            // 
            // rb_Renomear
            // 
            rb_Renomear.AutoSize = true;
            rb_Renomear.Location = new Point(232, 15);
            rb_Renomear.Name = "rb_Renomear";
            rb_Renomear.Size = new Size(79, 19);
            rb_Renomear.TabIndex = 1;
            rb_Renomear.TabStop = true;
            rb_Renomear.Text = "Renomear";
            rb_Renomear.UseVisualStyleBackColor = true;
            rb_Renomear.CheckedChanged += rb_Renomear_CheckedChanged;
            // 
            // ct_ListaPlanilhas
            // 
            ct_ListaPlanilhas.CheckOnClick = true;
            ct_ListaPlanilhas.FormattingEnabled = true;
            ct_ListaPlanilhas.Location = new Point(6, 15);
            ct_ListaPlanilhas.Name = "ct_ListaPlanilhas";
            ct_ListaPlanilhas.Size = new Size(220, 94);
            ct_ListaPlanilhas.TabIndex = 0;
            // 
            // tab_1
            // 
            tab_1.Controls.Add(checkBox1);
            tab_1.Controls.Add(label5);
            tab_1.Controls.Add(bt_executar);
            tab_1.Controls.Add(textBox2);
            tab_1.Controls.Add(textBox1);
            tab_1.Controls.Add(label6);
            tab_1.Controls.Add(label3);
            tab_1.Location = new Point(4, 24);
            tab_1.Name = "tab_1";
            tab_1.Padding = new Padding(3);
            tab_1.Size = new Size(405, 120);
            tab_1.TabIndex = 0;
            tab_1.Text = "Criar Nova Planilha";
            tab_1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(7, 54);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Incluir Filhas?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(157, 84);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(157, 52);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(45, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(57, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "SÓCIO";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(101, 56);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 1;
            label6.Text = "Quantas?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 22);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 0;
            label3.Text = "Sócio";
            // 
            // tab_2
            // 
            tab_2.Location = new Point(4, 24);
            tab_2.Name = "tab_2";
            tab_2.Padding = new Padding(3);
            tab_2.Size = new Size(405, 120);
            tab_2.TabIndex = 1;
            tab_2.Text = "tabPage2";
            tab_2.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 270);
            Controls.Add(ct_Tabs);
            Controls.Add(tb_resultado);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bt_pastapadrao);
            Controls.Add(tb_pastapdrao);
            Controls.Add(cb_opcao);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            ct_Tabs.ResumeLayout(false);
            tab_0.ResumeLayout(false);
            tab_0.PerformLayout();
            tab_1.ResumeLayout(false);
            tab_1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_resultado;
        private Button bt_executar;
        private Label label2;
        private Label label1;
        private Button bt_pastapadrao;
        private TextBox tb_pastapdrao;
        private ComboBox cb_opcao;
        private TabControl ct_Tabs;
        private TabPage tab_1;
        private Label label5;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Label label3;
        private TabPage tab_2;
        private CheckBox checkBox1;
        private TabPage tab_0;
        private CheckedListBox ct_ListaPlanilhas;
        private Button bt_ExecPlanilha;
        private RadioButton rb_Ativar;
        private RadioButton rb_Desativar;
        private RadioButton rb_Eliminar;
        private RadioButton rb_Renomear;
        private TextBox tb_NovoNome;
        private Label lb_NovoNome;
    }
}