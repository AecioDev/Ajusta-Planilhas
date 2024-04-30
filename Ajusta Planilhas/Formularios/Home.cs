using System.Diagnostics;
using Gestao_Planilhas.Classes.Dados.Repositorio;
using Gestao_Planilhas.Classes.Dados;
using Gestao_Planilhas.Classes.Processamento;

namespace Gestao_Planilhas
{
    public partial class Home : Form
    {
        private List<string> listaArquivos = new List<string>();
        private int codEmp = 0;
        private string PastaPadrao;
        private Image LogoEmp;
        private int EmpresaId;

        public Home()
        {
            InitializeComponent();
        }

        public Home(int _codEmp)
        {
            InitializeComponent();
            this.codEmp = _codEmp;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            VerEmpresa(codEmp);

            if(EmpresaId == 0)
            {
                MessageBox.Show("A Empresa Não foi cadastrada! Favor tentar novamente...", Utilitarios.msgCab,
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }

            try
            {
                // Obtenha os nomes dos arquivos no diretório
                listaArquivos = Directory.GetFiles(PastaPadrao).ToList();

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

        private void bt_executar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PastaPadrao))
            {
                ExcelProcessor ProcExcel = new ExcelProcessor();

                var caminhoResumo = ProcExcel.GeraResumoSocios(PastaPadrao, "ATUAL DISTRIBUIDORA");

                // Abre o arquivo Excel com o aplicativo padrão associado
                if (!string.IsNullOrEmpty(caminhoResumo))
                {
                    Process.Start(new ProcessStartInfo(caminhoResumo) { UseShellExecute = true });
                }
            }
            else
            {
                MessageBox.Show("Selecione a Pasta Padrão!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    caminhoCompleto = Path.Combine(PastaPadrao, nomeArquivo);
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

        private async void VerEmpresa(int codemp)
        {
            using (var context = new GPContext())
            {
                var EmpRep = new EmpresaRepository(context);

                var DadosEmp = await EmpRep.GetByIdAsync(codemp);
                if (DadosEmp != null)
                {
                    PastaPadrao = DadosEmp.PastaPadrao;
                    LogoEmp = Utilitarios.GetImage(DadosEmp.EmpresaLogo);
                    EmpresaId = DadosEmp.EmpresaId;
                }
                else
                {
                    //Abre o Menu Principal
                    CadEmpresa CadEmp = new CadEmpresa(0);
                    CadEmp.ShowDialog();
                }
            }
        }

        private void lb_Empresa_DoubleClick(object sender, EventArgs e)
        {
            CadEmpresa CadEmp = new CadEmpresa(EmpresaId);
            CadEmp.ShowDialog();
        }
    } //Final da Classe
}
