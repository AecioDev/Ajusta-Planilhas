using Gestao_Planilhas.Classes.Processamento;
using Microsoft.Data.Sqlite;

namespace Gestao_Planilhas.Classes.Dados
{
    public class AtualizaBD
    {
        public static string Script(int codScript)
        {
            //Nessa classe são criadas as alterações necessárias no banco de dados em cada atualização.
            //Inclusão de campos, alterações em campos, criação de indices etc.
            //LEMBRANDOOOOO que todas as Alterações na estrutura do Banco de dados feitas aqui, devem ser 
            //Feitas na Classe CriaTabelasBD impreterivelmente. isso para que ao criar o banco de dados 
            //o mesmo já seja criado na última versão.

            string script = "";
            switch (codScript)
            {
                default:
                    script = "FIM";
                    break;
            }

            return script;
        }

        public static bool Existe(int mode, string TABELA, string COLUNA)
        {
            string scriptTable = "";
            string retorno = "";
            bool existe = false;

            switch (mode)
            {
                case 0: //Tabela
                    scriptTable = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TABELA + "'";
                    break;
                case 1: //Campo
                    scriptTable = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TABELA + "' AND COLUMN_NAME = '" + COLUNA + "'";
                    break;
            }

            SqliteConnection conexao = Utilitarios.CriaConexao();
            SqliteCommand comd = new SqliteCommand(scriptTable, conexao);
            conexao.Open();
            SqliteDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {
                retorno = reader.GetString(0);
            }
            conexao.Close();

            if (retorno.Length > 0)
                existe = true;

            return existe;
        }
    }
}
