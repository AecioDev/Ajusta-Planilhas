using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajusta_Planilhas
{
    public partial class Home : Form
    {
        private List<string> listaArquivos = new List<string>();

        public Home()
        {
            InitializeComponent();
        }

        private void bt_pastapadrao_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                tb_pastapdrao.Text = folderBrowserDialog.SelectedPath;

                string diretorio = tb_pastapdrao.Text;

                try
                {
                    // Obtenha os nomes dos arquivos no diretório
                    listaArquivos = Directory.GetFiles(diretorio).ToList();

                    // Adicione os nomes dos arquivos ao CheckedListBox
                    ct_ListaPlanilhas.Items.Clear();
                    foreach (string arquivo in listaArquivos)
                    {
                        ct_ListaPlanilhas.Items.Add(Path.GetFileName(arquivo));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao listar arquivos: {ex.Message}", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Nenhum diretório selecionado!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bt_executar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_pastapdrao.Text))
            {
                ExcelProcessor ProcExcel = new ExcelProcessor();

                ProcExcel.GeraResumoSocios(tb_pastapdrao.Text, "ATUAL DISTRIBUIDORA");

            }
            else
            {
                MessageBox.Show("Selecione a Pasta Padrão!!!", "Atenção!!!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bt_pastapadrao.Focus();
            }
        }

        private void bt_ExecPlanilha_Click(object sender, EventArgs e)
        {
            int mudou = 0;
            int indice = 0;
            string nomeArquivo = "";
            string caminhoCompleto = "";

            if (ct_ListaPlanilhas.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nenhum arquivo selecionado!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ct_ListaPlanilhas.CheckedItems.Count > 1)
            {
                MessageBox.Show("Selecione apenas UMA planilha!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Obtenha o caminho completo do arquivo selecionado
                foreach (var planilha in ct_ListaPlanilhas.CheckedItems)
                {
                    nomeArquivo = planilha.ToString();
                    caminhoCompleto = Path.Combine(tb_pastapdrao.Text, nomeArquivo);
                    indice = listaArquivos.IndexOf(caminhoCompleto);
                }

                if (rb_Renomear.Checked)
                {
                    if (!string.IsNullOrWhiteSpace(tb_NovoNome.Text))
                    {

                        ExcelProcessor ProcExcel = new ExcelProcessor();

                        ProcExcel.AlterarNomeSocio(caminhoCompleto, tb_NovoNome.Text);

                        mudou = 1;
                    }
                    else
                    {
                        MessageBox.Show("Informe o Novo Nome!!!", "Atenção!!!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tb_NovoNome.Focus();
                    }
                }

                if (rb_Eliminar.Checked)
                {
                    DeletarArquivo(caminhoCompleto);
                    ct_ListaPlanilhas.Items.Remove(nomeArquivo);
                }

                if (rb_Ativar.Checked)
                {

                }

                if (rb_Desativar.Checked)
                {

                }

                if (mudou > 0)
                {
                    listaArquivos[indice] = tb_NovoNome.Text;
                    ct_ListaPlanilhas.Items[indice] = tb_NovoNome.Text;
                }
            }
        }

        private void DeletarArquivo(string nomeArquivo)
        {
            try
            {
                // Verifica se o arquivo existe antes de deletar
                if (File.Exists(nomeArquivo))
                {
                    File.Delete(nomeArquivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao deletar o arquivo: {ex.Message}", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rb_Renomear_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Renomear.Checked)
            {
                lb_NovoNome.Visible = true;
                tb_NovoNome.Visible = true;
            }
            else
            {
                lb_NovoNome.Visible = false;
                tb_NovoNome.Visible = false;
            }
        }
    } //Final da Classe
}
