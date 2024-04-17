using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajusta_Planilhas
{
    public class ExcelProcessor
    {
        public void AlterarNomeSocio(string caminhoArquivo, string novoNome)
        {
            // Carrega o arquivo Excel
            FileInfo fileInfo = new FileInfo(caminhoArquivo);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    if (worksheet.Name == "Janeiro")
                    {
                        // Altera o nome do sócio na célula B2 da planilha de Janeiro
                        worksheet.Cells["B2"].Value = novoNome;
                    }
                    else
                    {
                        // Atualiza a fórmula na célula B2 para referenciar a célula B2
                        // da planilha de Janeiro nas demais planilhas
                        worksheet.Cells["B2"].Formula = $"='Janeiro'! B2";
                    }
                }
                
                // Salva o arquivo
                package.Save();
            }

            // Renomeia o arquivo após ter salvo as alterações
            RenomearArquivo(fileInfo, novoNome);

            MessageBox.Show("Nome do sócio alterado com sucesso!!!", "Atenção!!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GeraResumoSocios(string pastaPadrao, string empresa)
        {
            List<string> listaPlanilhas = new List<string>();
            string caminhoResumo = pastaPadrao + @"\RESUMO_SOCIOS_" + empresa + "_" +DateTime.Now.ToString("G")
                .Replace("/","")
                .Replace(":","")
                .Replace(" ","") 
                + ".xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (ExcelPackage package = new ExcelPackage())
                {
                    for (int mes = 1; mes <= 12; mes++)
                    {
                        // Adiciona uma nova planilha para cada mês
                        string nomeMes = ObterNomeMes(mes);
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(nomeMes);

                        // Estilo para o cabeçalho
                        ExcelRange rangeHeader = worksheet.Cells["A1:G1"];
                        rangeHeader.Merge = true;
                        rangeHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rangeHeader.Style.Font.Size = 25;
                        rangeHeader.Style.Font.Name = "Calibri";
                        rangeHeader.Value = empresa.ToUpper();

                        // Estilo para o subtítulo
                        ExcelRange rangeSubtitulo = worksheet.Cells["A2:G2"];
                        rangeSubtitulo.Merge = true;
                        rangeSubtitulo.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rangeSubtitulo.Style.Font.Size = 18;
                        rangeSubtitulo.Style.Font.Name = "Calibri";
                        rangeSubtitulo.Value = "RESULTADO DE GANHOS POR SÓCIO";

                        // Nome do mês e ano
                        worksheet.Cells["A3"].Value = nomeMes;
                        worksheet.Cells["F3"].Value = "ANO:";
                        worksheet.Cells["G3"].Value = DateTime.Now.Year;

                        // Cabeçalho da tabela
                        worksheet.Cells["A4"].Value = "Sócio";
                        worksheet.Cells["B4"].Value = "Valor Total";
                        worksheet.Cells["C4"].Value = "Recebimento";
                        worksheet.Cells["D4"].Value = "Percentual";
                        worksheet.Cells["E4"].Value = "Mercadorias Pagas";
                        worksheet.Cells["F4"].Value = "Sócio Ganhou";
                        worksheet.Cells["G4"].Value = "Firma Ganhou";

                        // Linhas em branco
                        for (int linha = 5; linha <= 10; linha++)
                        {
                            worksheet.Cells[linha, 1, linha, 7].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                        }

                        // Fórmula na coluna D
                        for (int linha = 5; linha <= 10; linha++)
                        {
                            worksheet.Cells[linha, 4].Formula = $"=IF(B{linha} > 0, C{linha}/B{linha}, 0)";
                            worksheet.Cells[linha, 4].Style.Numberformat.Format = "0.00%";
                        }

                        // Somatório
                        worksheet.Cells["A11"].Value = "Total";
                        worksheet.Cells["B11"].Formula = $"=SUM(B5:B10)";
                        worksheet.Cells["C11"].Formula = $"=SUM(C5:C10)";
                        worksheet.Cells["D11"].Formula = $"=IF(B11 > 0, C11/B11, 0)";
                        worksheet.Cells["D11"].Style.Numberformat.Format = "0.00%";
                        worksheet.Cells["E11"].Formula = $"=SUM(E5:E10)";
                        worksheet.Cells["F11"].Formula = $"=SUM(F5:F10)";
                        worksheet.Cells["G11"].Formula = $"=SUM(G5:G10)";
                    }

                    // Salva o arquivo
                    package.SaveAs(new FileInfo(caminhoResumo));
                }

                MessageBox.Show("RESUMO GERADO com sucesso!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar a planilha de Resumo: {ex.Message}", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //try
            //{                
            //    listaPlanilhas = Directory.GetFiles(pastaPadrao).ToList();
                                
            //    foreach (string arquivo in listaPlanilhas)
            //    {
            //        // Carrega o arquivo Excel
            //        FileInfo fileInfo = new FileInfo(arquivo);

                   

            //        using (ExcelPackage package = new ExcelPackage(fileInfo))
            //        {
            //            foreach (var worksheet in package.Workbook.Worksheets)
            //            {                            
            //                if (worksheet.Name == "Janeiro")
            //                {                                
            //                    var valida01 = worksheet.Cells["A13"].Value;    //Tem q Ser DESPESAS
            //                    var valida02 = worksheet.Cells["C11"].Value;    //Tem q Ser RECEITAS

            //                }
            //                else
            //                {
            //                    // Atualiza a fórmula na célula B2 para referenciar a célula B2
            //                    // da planilha de Janeiro nas demais planilhas
            //                    worksheet.Cells["B2"].Formula = $"='Janeiro'! B2";
            //                }

            //            }

            //            // Salva o arquivo
            //            package.Save();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Erro ao listar arquivos: {ex.Message}", "Atenção!!!",
            //    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //MessageBox.Show("Nome do sócio alterado com sucesso!!!", "Atenção!!!",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ObterNomeMes(int mes)
        {
            return new DateTime(2024, mes, 1).ToString("MMMM");
        }

        private void RenomearArquivo(FileInfo arquivo, string novoNome)
        {
            try
            {
                string novoCaminho = Path.Combine(arquivo.Directory.FullName, novoNome + arquivo.Extension);

                if (arquivo.FullName != novoCaminho)
                {
                    arquivo.MoveTo(novoCaminho);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao renomear o arquivo: {ex.Message}", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
