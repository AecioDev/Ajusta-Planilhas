using Gestao_Planilhas.Classes.Dados;
using Gestao_Planilhas.Classes.Dados.Estrutura;
using Gestao_Planilhas.Classes.Dados.Repositorio;
using Gestao_Planilhas.Classes.Entidades;
using Gestao_Planilhas.Classes.Processamento;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Gestao_Planilhas
{
    public partial class Acesso : Form
    {
        public Acesso()
        {
            InitializeComponent();
        }

        private string PathBD = "";
        private int versao = Utilitarios.versao;
        private string msgCab = Utilitarios.msgCab;

        private void Acesso_Load(object sender, EventArgs e)
        {
            //Primeiro Verifica se existe o Banco de Dados / Arquivo de Conexão.
            VerificaBD();
            IniciaUsuario();
        }

        private async void IniciaUsuario()
        {
            //Se o Banco de Dados existir Busca o Usuário que salvou o login
            using (var context = new GPContext())
            {
                var userRep = new UserRepository(context);

                var userFlag = await userRep.GetFlagAsync();

                if (userFlag != null)
                {
                    tb_Usuario.Text = userFlag.UserEmail.Trim();
                    tb_Senha.Text = Utilitarios.Base64Decode(userFlag.UserSenha);
                }
            }
        }

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            LogarUsuario();
        }

        private async void LogarUsuario()
        {
            //Se o Banco de Dados existir Busca o Usuário que salvou o login
            using (var context = new GPContext())
            {
                int CodUser = 0;
                string SenhaUser = "";

                if (tb_Usuario.Text != "" && tb_Senha.Text != "")
                {
                    try
                    {
                        if (tb_Usuario.Text == "ADMIN" && tb_Senha.Text == "BD9854") //Abre a tela para Manutenção no Banco de Dados
                        {
                            //ConexaoSQL conSql = new ConexaoSQL();
                            //conSql.ShowDialog();
                            //tb_senUser.Text = "";
                            //return;
                            MessageBox.Show("Sem tela ainda...");
                        }

                        //SenHash = Utilitarios.HashPassword(tb_Senha.Text);

                        //1 - Verifica se o usuário informado no Campo existe no BD e busca os dados dele.

                        var userRep = new UserRepository(context);

                        var userLogin = await userRep.GetByEmailAsync(tb_Usuario.Text);

                        if (userLogin != null)
                        {
                            CodUser = userLogin.UserId;
                            SenhaUser = userLogin.UserSenha; //Senha gravada no BD

                            if (CodUser > 0) //Achou o bendito
                            {
                                //2 - Verifica a Senha do bixo
                                if (Utilitarios.VerifyPassword(tb_Senha.Text, SenhaUser)) //Retorna true ou false 
                                {
                                    this.Hide();

                                    //Se o bendito quer gravar a senha
                                    if (cb_Lembrar.Checked)
                                    {
                                        userLogin.UserFlag = Utilitarios.Base64Encode(tb_Senha.Text);
                                        await userRep.UpdateAsync(userLogin);
                                    }
                                    else
                                    {
                                        userLogin.UserFlag = "";
                                        await userRep.UpdateAsync(userLogin);
                                    }

                                    //Abre o Menu Principal
                                    Home home = new Home(CodUser);
                                    home.ShowDialog();

                                    tb_Usuario.Clear();
                                    tb_Senha.Clear();
                                    tb_Rodape.ForeColor = SystemColors.Control;
                                    tb_Rodape.Text = "Bem Vindo !!!";

                                    this.Show();
                                }
                                else
                                {
                                    tb_Rodape.ForeColor = Color.DarkRed;
                                    tb_Rodape.Text = "Senha Incorreta!!!";
                                    tb_Senha.SelectAll();
                                    tb_Senha.Focus();
                                }
                            }
                            else
                            {
                                tb_Rodape.ForeColor = Color.DarkRed;
                                tb_Rodape.Text = "Usuário NÃO Encontrado!!!";
                                tb_Usuario.SelectAll();
                                tb_Usuario.Focus();
                            }
                        }
                        else
                        {
                            tb_Rodape.ForeColor = Color.DarkRed;
                            tb_Rodape.Text = "Usuário NÃO Encontrado!!!";
                            tb_Usuario.SelectAll();
                            tb_Usuario.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problemas ao consultar o banco de dados!!!\n" + "\nDetalhes abaixo:" + ex.Message, msgCab);
                        Application.Exit();
                    }
                }
                else
                {
                    if (tb_Usuario.Text == "" && tb_Senha.Text == "")
                    {
                        tb_Rodape.ForeColor = Color.DarkRed;
                        tb_Rodape.Text = "Informe Usuário e Senha!!!";
                    }
                    else
                    {
                        if (tb_Senha.Text == "")
                        {
                            tb_Rodape.ForeColor = Color.DarkRed;
                            tb_Rodape.Text = "Informe uma Senha!!!";
                        }

                        if (tb_Usuario.Text == "")
                        {
                            tb_Rodape.ForeColor = Color.DarkRed;
                            tb_Rodape.Text = "Informe um Usuário!!!";
                        }
                    }
                }
            }
        }

        private void lb_RecSenha_Click(object sender, EventArgs e)
        {
            RecuperaSenha();
        }

        private void lb_NovoAcesso_Click(object sender, EventArgs e)
        {
            CadAcesso newAcesso = new CadAcesso();
            newAcesso.ShowDialog();
        }

        private async void RecuperaSenha()
        {
            if (!string.IsNullOrEmpty(tb_Usuario.Text))
            {
                using (var context = new GPContext())
                {
                    var userRep = new UserRepository(context);

                    var DadosUser = await userRep.GetByEmailAsync(tb_Usuario.Text);

                    if (DadosUser != null)
                    {
                        CadAcesso newAcesso = new CadAcesso(DadosUser.UserId);
                        newAcesso.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum Usuário encontrado para o e-mail informado!!!",
                               Utilitarios.msgCab, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }                
            }
            else
            {
                MessageBox.Show("Favor informe o e-mail para recuperar a Senha!!!",
                       Utilitarios.msgCab, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void VerificaBD()
        {
            string pastaBD = "";

            if (!File.Exists(Utilitarios.PathArquivo))
            {
                pastaBD = Utilitarios.folder;

                if (!Utilitarios.ValidaBancoDados(pastaBD))
                {
                    MessageBox.Show("Problemas ao Criar a Estrutura de Banco de Dados!!!",
                        Utilitarios.msgCab, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }

            }
            else
            {
                if (!Utilitarios.ValidaBancoDados(""))
                {
                    MessageBox.Show("Problemas ao Atualizar a Estrutura de Banco de Dados!!!",
                    Utilitarios.msgCab, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
                else
                {
                    //Mansagem na tela de Splash
                    //MessageBox.Show("Estrutura de Banco de Dados Atualizada com Sucesso!!!", Funcoes.msgCab,
                    //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        
    }
}
