using Gestao_Planilhas.Classes.Dados.Repositorio;
using Gestao_Planilhas.Classes.Dados;
using System.Windows.Forms;
using Gestao_Planilhas.Classes.Entidades;
using Gestao_Planilhas.Classes.Processamento;
using OfficeOpenXml.ConditionalFormatting.Contracts;

namespace Gestao_Planilhas
{
    public partial class CadEmpresa : Form
    {
        private int id;
        private string extimg;
        public CadEmpresa(int _id)
        {
            InitializeComponent();
            id = _id;
            if(_id > 0)
            {
                lb_Empresa.Text = "Editar Empresa";
            }
        }

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_pastapdrao_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                tb_pastapdrao.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Nenhum diretório selecionado!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pb_LogoEmp_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscaImg = new OpenFileDialog();

            // Define o filtro para mostrar apenas arquivos de imagem
            buscaImg.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (buscaImg.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo selecionado
                string imagePath = buscaImg.FileName;
                extimg = Path.GetExtension(imagePath);

                // Exibe a imagem no PictureBox
                pb_LogoEmp.Image = Image.FromFile(imagePath);
            }
        }

        private void bt_Salvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_nomeEmp.Text) && !string.IsNullOrEmpty(tb_pastapdrao.Text))
            {
                GravaEmpresaAsync();
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor Informar o Nome e a Pasta Padrão das Planilhas...", Utilitarios.msgCab,
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void GravaEmpresaAsync()
        {
            //Se o Banco de Dados existir Busca o Usuário que salvou o login
            using (var context = new GPContext())
            {                
                var EmpRep = new EmpresaRepository(context);
                byte[] ImageByte = Utilitarios.SetImage(pb_LogoEmp.InitialImage, extimg);

                if (pb_LogoEmp.Image != null)
                {
                    ImageByte = Utilitarios.SetImage(pb_LogoEmp.Image, extimg);
                }

                if (id > 0)
                {
                    var CadEmp = await EmpRep.GetByIdAsync(id);
                    CadEmp.EmpresaNome = tb_nomeEmp.Text;
                    CadEmp.PastaPadrao = tb_pastapdrao.Text;
                    CadEmp.EmpresaLogo = ImageByte;
                    await EmpRep.UpdateAsync(CadEmp);
                }
                else
                {
                    var CadEmp = new Empresa { EmpresaNome = tb_nomeEmp.Text, PastaPadrao = tb_pastapdrao.Text, EmpresaLogo = ImageByte };
                    await EmpRep.AddAsync(CadEmp);
                }
            }
        }

    }
}
