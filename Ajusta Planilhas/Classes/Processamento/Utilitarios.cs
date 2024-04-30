using Gestao_Planilhas.Classes.Dados;
using Microsoft.Data.Sqlite;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Gestao_Planilhas.Classes.Dados.Repositorio;
using System.Drawing.Imaging;

namespace Gestao_Planilhas.Classes.Processamento
{
    public class Utilitarios
    {
        public static int versao = 1;

        public static string folder = Environment.CurrentDirectory + @"\Dados\";
        public static string PathArquivo = folder + "Connection.cfg"; //Caminho completo do arquivo        
        public static string PathBD = folder + "GestaoPlanilhas.db";

        //String de Conexxão do Banco de Dados
        //public static string strConn = string.Format("DataSource={0}; Password='{1}'", PathBD, "9854");
        public static string strConn = string.Format("DataSource={0}", PathBD);
        public static string msgCab = "Gestão Planilhas";

        #region Leitura e Gravação do Arquivo de Conexão
        public static void CriArquivoConexao()
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    DirectoryInfo diretorio = Directory.CreateDirectory(folder);
                    diretorio.Attributes = FileAttributes.Hidden;
                }

                FileStream fs = new FileStream(PathArquivo, FileMode.Create, FileAccess.ReadWrite);

                //MessageBox.Show("Arquivo de Conexão Criado com Sucesso!!!", msgCab,
                //            MessageBoxButtons.OK, MessageBoxIcon.Information);

                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o arquivo de Conexão!!!\n\n" + ex.Message, msgCab,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void GravaArquivoConexao(string conexao)
        {
            try
            {
                FileStream fs = new FileStream(PathArquivo, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(conexao);

                sw.Close(); //grava e fecha

                //MessageBox.Show("Conexão gravada com Sucesso!!!", msgCab,
                //            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar a conexão no arquivo de Conexão!!!\n\n" + ex.Message, msgCab,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string Busca_Conexao()
        {
            string connstr = "";
            try
            {
                FileStream fs = new FileStream(PathArquivo, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                connstr = sr.ReadToEnd();
                sr.Close(); //grava e fecha

                return connstr.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar o arquivo de Conexão!!!\n\n" + ex.Message, msgCab,
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return connstr;

        }
        public static SqliteConnection CriaConexao()
        {
            SqliteConnection Conn = new SqliteConnection(Busca_Conexao());
            return Conn;
        }
        #endregion

        public static bool ValidaBancoDados(string pastaBD)
        { 
            int retorno = 0;
            int scriptBD = 0;
            string scriptTable = "";
            SqliteConnection conexao = null;
            SqliteCommand comd = null;

            try
            {
                if (pastaBD.Length > 0)
                {
                    #region Novo Cria banco de Dados
                    /********************** Trecho que cria o Banco de Dados e as Tabelas *****************************/
                    if (!Directory.Exists(pastaBD))
                    {
                        DirectoryInfo diretorio = Directory.CreateDirectory(pastaBD);
                        diretorio.Attributes = FileAttributes.Hidden;
                    }

                    pastaBD = pastaBD + @"\GestaoPlanilhas.db";
                    scriptTable = string.Format("DataSource={0}", pastaBD);

                    GravaArquivoConexao(scriptTable);

                    using (var context = new GPContext())
                    {
                        // Criar o banco de dados se não existir
                        context.Database.EnsureCreated();
                    }

                    /********************** Faz a inserção dos dados iniciais. *****************************/
                    //Mensagem - "Inserindo dados iniciais...\n";
                    conexao = CriaConexao();
                    conexao.Open();
                    scriptBD = 0;
                    while (true)
                    {
                        scriptTable = CriaTabelasBD.InsereDados(scriptBD); //Carrega o script
                        if (scriptTable != "FIM")
                        {
                            comd = new SqliteCommand(scriptTable, conexao);
                            retorno = comd.ExecuteNonQuery();   //Executa o script
                            scriptBD++;
                        }
                        else
                            break;
                    }
                    //Mensagem - "Dados iniciais inseridos com sucesso!!! \n";
                    conexao.Close();
                    #endregion
                }
                else
                {
                    /********************** Este Trecho faz a Atualização do Banco de Dados *****************************/

                    //Busca o número do último script executado
                    //Mensagem: Aguarde... Verificando Estrutura do Banco de Dados
                    conexao = CriaConexao();
                    scriptTable = "SELECT scriptBD FROM SYS0000 WHERE versaoSistema = " + versao;
                    comd = new SqliteCommand(scriptTable, conexao);
                    conexao.Open();
                    SqliteDataReader reader = comd.ExecuteReader();
                    while (reader.Read())
                    {
                        scriptBD = reader.GetInt32(0);
                    }
                    conexao.Close();

                    //Cria as tabelas do banco de dados
                    //Mensagem - "Criando as Tabelas...\n";
                    conexao = CriaConexao();
                    conexao.Open();

                    while (true)
                    {
                        scriptTable = AtualizaBD.Script(scriptBD); //Carrega o script
                        if (scriptTable != "FIM")
                        {
                            comd = new SqliteCommand(scriptTable, conexao);
                            retorno = comd.ExecuteNonQuery();   //Executa o script
                            scriptBD++;
                        }
                        else
                            break;
                    }
                    //Mensagem - "Tabelas criadas com sucesso!!!";
                    conexao.Close();

                    //Atualiza Tabela de Parametros SYS000 com o ultimo script executado
                    conexao = CriaConexao();
                    scriptTable = "UPDATE SYS0000 SET scriptBD = " + scriptBD + " WHERE versaoSistema = " + versao; //Grava o próximo script a ser executado
                    comd = new SqliteCommand(scriptTable, conexao);
                    conexao.Open();
                    comd.ExecuteNonQuery();
                    conexao.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar o Banco De Dados!!!\n\n" + ex.Message, msgCab,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        // Método para criptografar uma senha usando SHA256
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertendo a senha para um array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertendo o array de bytes para uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Método para verificar se uma senha não criptografada corresponde a uma senha criptografada
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Criptografando a senha não criptografada
            string hashedInput = HashPassword(password);

            // Comparando as senhas criptografadas
            return hashedInput.Equals(hashedPassword);
        }

        public static void SendEmail(string to, string subject, string body)
        {
            string fromAddress = "espiranda.ms@gmail.com"; // Seu endereço de e-mail
            string fromPassword = "uwop qqmi epvd eclv"; // Sua senha de aplicativo gerada

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // O Gmail requer SSL
                smtp.Port = 587; // Porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // Modo de envio
                smtp.UseDefaultCredentials = false; // Não utilize credenciais padrão

                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000; // Tempo limite de conexão

                var codbase = fromAddress + DateTime.Now.ToString("YYYYMMDD");
                var codigo = Base64Encode(codbase);

                

                // Crie uma mensagem de e-mail
                var message = new MailMessage
                {
                    From = new MailAddress(fromAddress),
                    Subject = "Recuperação de Senha Gestão Planilhas",
                    Body = "Informe o código abaixo no aplicativo para recuperar a sua senha.\n\n" + "<h2>" + codigo + "<h2>",
                    IsBodyHtml = true // Se o corpo é HTML
                };

                message.To.Add("destinatario@email.com"); // Endereço do destinatário

                // Anexe arquivos, se necessário
                // message.Attachments.Add(new Attachment("caminho/do/arquivo.txt"));

                try
                {
                    smtp.Send(message);
                    Console.WriteLine("E-mail enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
                }
            }
        }

        public async void GravaCodigo(string email, string codrec)
        {
            using (var context = new GPContext())
            {
                var SysRep = new SysRepository(context);

                var dadosSys = await SysRep.GetByIdAsync(1);
                if (dadosSys != null)
                {
                    dadosSys.CodRepPass = codrec;
                    await SysRep.UpdateAsync(dadosSys);
                }
            }
        }

        //Função utilizada para converter a imagem em binário para salvar no banco de dados.
        public static byte[] SetImage(Image picFoto, string ext)
        {
            byte[] img_array = null;

            //convertendo a foto para dados binários
            if (picFoto != null)
            {
                MemoryStream ms = new MemoryStream();
                if (ext == ".png")
                    picFoto.Save(ms, ImageFormat.Png);

                if (ext == ".jpg")
                    picFoto.Save(ms, ImageFormat.Jpeg);

                if (ext == ".gif")
                    picFoto.Save(ms, ImageFormat.Gif);

                byte[] foto_array = new byte[ms.Length];

                ms.Position = 0;
                ms.Read(foto_array, 0, foto_array.Length);
                img_array = foto_array;
            }

            return img_array;
        }

        public static Image GetImage(byte[] foto)
        {
            Image imgFoto = null;

            if (foto.Length > 0)
            {
                MemoryStream ms = new MemoryStream(foto, true);

                imgFoto = Image.FromStream(ms, true);
            }
            return imgFoto;
        }
    }
}
