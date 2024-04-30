using Gestao_Planilhas.Classes.Dados.Repositorio;
using Gestao_Planilhas.Classes.Dados;
using Gestao_Planilhas.Classes.Processamento;
using Gestao_Planilhas.Classes.Entidades;

namespace Gestao_Planilhas
{
    public partial class CadAcesso : Form
    {
        public CadAcesso()
        {
            InitializeComponent();
        }

        private int UserId;

        public CadAcesso(int _id)
        {
            InitializeComponent();
            this.UserId = _id;
        }

        private void CadAcesso_Load(object sender, EventArgs e)
        {
            if(UserId > 0)
            {
                lb_Cab.Text = "Editar Acesso";
                pn_Combos.Visible = true;
                CarregaAcesso();
            }
            else
            {
                pn_Combos.Visible = false;
            }
        }

        private void bt_Salvar_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                GravaAcesso();
            }
        }

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private async void GravaAcesso()
        {
            using (var context = new GPContext())
            {
                try
                {
                    var userRep = new UserRepository(context);

                    if (UserId > 0)
                    {
                        var DadosUser = await userRep.GetByIdAsync(UserId);

                        if (DadosUser != null)
                        {
                            DadosUser.UserNome = tb_nome.Text;
                            DadosUser.UserEmail = tb_Email.Text;
                            DadosUser.UserSenha = Utilitarios.HashPassword(tb_Senha.Text);

                            if (cb_Status.SelectedIndex == 0)
                                DadosUser.UserStatus = "A";
                            else
                                DadosUser.UserStatus = "I";

                            if (cb_Perfil.SelectedIndex == 0)
                                DadosUser.UserPerfil = "A"; //Administrador
                            else
                                DadosUser.UserPerfil = "U"; //Usuario

                            await userRep.UpdateAsync(DadosUser);
                        }
                    }
                    else
                    {
                        var DadosUser = new Usuario
                        {
                            UserNome = tb_nome.Text,
                            UserEmail = tb_Email.Text,
                            UserSenha = Utilitarios.HashPassword(tb_Senha.Text),
                            UserStatus = "A",
                            UserPerfil = "A",
                            UserFlag = ""
                        };

                        await userRep.AddAsync(DadosUser);
                    }

                    MessageBox.Show("Dados de Acesso Gravadas com Sucesso!!!",
                        Utilitarios.msgCab, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas ao Gravar os Dados!!!\n" + "\nDetalhes abaixo:" + ex.Message, 
                        Utilitarios.msgCab, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void CarregaAcesso()
        {
            using (var context = new GPContext())
            {
                var userRep = new UserRepository(context);

                var DadosUser = await userRep.GetByIdAsync(UserId);

                if (DadosUser != null)
                {
                    tb_nome.Text = DadosUser.UserNome;
                    tb_Email.Text = DadosUser.UserEmail;
                    tb_Senha.Text = DadosUser.UserSenha.Substring(0, 10);

                    if (DadosUser.UserStatus == "A")
                        cb_Status.SelectedIndex = 0;
                    else
                        cb_Status.SelectedIndex = 1;

                    if (DadosUser.UserPerfil == "A")
                        cb_Perfil.SelectedIndex = 0;
                    else
                        cb_Perfil.SelectedIndex = 1;

                }
            }
        }

        private bool ValidaCampos()
        {
            bool isvalid = true;

            if (tb_nome.Text.Length <= 0)
            {
                MessageBox.Show("Favor informar o Nome do Usuário!!!", Utilitarios.msgCab,
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isvalid = false;
            }

            if (tb_Email.Text.Length <= 0)
            {
                MessageBox.Show("Favor informar um e-mail válido!!!", Utilitarios.msgCab,
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isvalid = false;
            }

            if (tb_Senha.Text.Length <= 0)
            {
                MessageBox.Show("Favor informar uma senha!!!", Utilitarios.msgCab,
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isvalid = false;
            }

            return isvalid;
        }
    }
}
