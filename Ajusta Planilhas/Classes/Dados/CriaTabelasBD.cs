namespace Gestao_Planilhas.Classes.Dados
{
    public class CriaTabelasBD
    {
        //Nessa Classe Será Incluída a Criação de Todas as Tabelas do Banco de Dados 
        //No formato do SQL Server Compact
        //Na Forma de um único Script.
        //Isso inclui a criação das Tabelas e integridade Referencial que se Fizer necessário.

        public static string CriaTabelas(int codScript)
        {
            string script = "";
            switch (codScript)
            {
                case 0: //-- Script Date: 24/03/2019 18:50
                    script = "CREATE TABLE [SYS0000]([SysId] int IDENTITY (1,1) NOT NULL, [VersaoSistema] int NULL, [ScriptBD] int NULL, CONSTRAINT [PK_SYS0000] PRIMARY KEY ([SysId]));";
                    break;
                case 1:
                    script = "CREATE TABLE [Usuarios]([UserId] int IDENTITY (1,1) NOT NULL, [UserStatus] nvarchar(1) NULL, [UserNome] nvarchar(150) NULL, [UserEmail]nvarchar(150) NULL, [UserSenha] nvarchar(20) NULL, [UserPerfil] nvarchar(256) NULL, [UserFlag] nvarchar(1) NULL, CONSTRAINT [PK_Usuario]PRIMARY KEY ([UserId]));\r\n";
                    break;

                default:
                    script = "FIM";
                    break;
            }

            return script;
        }

        public static string CriaIndices(int codScript)
        {
            string script = "";
            switch (codScript) //Cria Indices
            {
                default:
                    script = "FIM";
                    break;
            }

            return script;
        }

        public static string CriaReferencias(int codScript)
        {
            string script = "";
            switch (codScript) //Cria Referencias
            {
                default:
                    script = "FIM";
                    break;
            }

            return script;
        }

        public static string InsereDados(int codScript)
        {
            string script = "";
            switch (codScript)
            {
                case 0:
                    script = "INSERT INTO Usuarios (UserStatus, UserNome, UserEmail, UserSenha, UserPerfil, UserFlag) " +
                             "VALUES('A', 'Conta Interna de Administração', 'admin@admin.com', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', 'A', 'N');";
                    break;
                case 1:
                    script = "INSERT INTO SYS0000 (VersaoSistema, ScriptBD) VALUES(1, 0);";
                    break;
                default:
                    script = "FIM";
                    break;
            }

            return script;
        }
    }
}
