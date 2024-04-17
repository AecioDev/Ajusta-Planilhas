using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

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
                        rangeHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rangeHeader.Style.Font.Size = 26;
                        //rangeHeader.Style.Font.Name = "Calibri";
                        rangeHeader.Style.Font.Bold = true;
                        rangeHeader.Value = empresa.ToUpper();

                        // Estilo para o subtítulo
                        ExcelRange rangeSubtitulo = worksheet.Cells["A2:G2"];
                        rangeSubtitulo.Merge = true;
                        rangeSubtitulo.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rangeSubtitulo.Style.Font.Size = 18;
                        rangeSubtitulo.Style.Font.Bold = true;
                        rangeSubtitulo.Value = "RESULTADO DE GANHOS POR SÓCIO";

                        // Nome do mês e ano
                        worksheet.Cells["A3"].Value = nomeMes;
                        worksheet.Cells["A3"].Style.Font.Size = 20;
                        worksheet.Cells["A3"].Style.Font.Bold = true;

                        worksheet.Cells["F3"].Value = "ANO:";
                        worksheet.Cells["F3"].Style.Font.Size = 20;
                        worksheet.Cells["F3"].Style.Font.Bold = true;
                        worksheet.Cells["F3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;


                        worksheet.Cells["G3"].Value = DateTime.Now.Year;
                        worksheet.Cells["G3"].Style.Font.Size = 20;
                        worksheet.Cells["G3"].Style.Font.Bold = true;

                        // Títulos da tabela
                        worksheet.Cells["A4"].Value = "Sócio";
                        worksheet.Cells["B4"].Value = "Valor Total";
                        worksheet.Cells["C4"].Value = "Recebimento";
                        worksheet.Cells["D4"].Value = "Percentual";
                        worksheet.Cells["E4"].Value = "Mercadorias Pagas";
                        worksheet.Cells["F4"].Value = "Sócio Ganhou";
                        worksheet.Cells["G4"].Value = "Firma Ganhou";

                        // Estilo para os Títulos
                        worksheet.Columns[1].Width = 30;
                        worksheet.Columns[2].Width = 25;
                        worksheet.Columns[3].Width = 25;
                        worksheet.Columns[4].Width = 15;
                        worksheet.Columns[5].Width = 25;
                        worksheet.Columns[6].Width = 25;
                        worksheet.Columns[7].Width = 25;

                        worksheet.Rows[4].Height = 34;

                        rangeHeader = worksheet.Cells["A4:G4"];
                        rangeHeader.Style.Font.Size = 16;
                        rangeHeader.Style.Font.Bold = true;
                        rangeHeader.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rangeHeader.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        rangeHeader.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        rangeHeader.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                        for (int col = 1; col <= 7; col++)
                        {
                            worksheet.Cells[4, col].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        }
                        //Fim do tratamento do cabeçalho

                        //Navega nos Arquivos dos sócios valida se é a planilha correta e Pega o Nome 
                        listaPlanilhas = Directory.GetFiles(pastaPadrao).ToList();
                        int lin = 5;

                        foreach (string arqSocio in listaPlanilhas)
                        {
                            string valida01 = "";
                            string valida02 = "";
                            string NomeSocio = "";

                            // Carrega o arquivo Excel
                            FileInfo fileSocio = new FileInfo(arqSocio);
                            
                            using (ExcelPackage packageSocios = new ExcelPackage(fileSocio))
                            {
                                // Busca os Dados do Sócio
                                var wksocios = packageSocios.Workbook.Worksheets["Janeiro"];                                   
                                valida01 = wksocios.Cells["A13"].Value.ToString();    //Tem q Ser DESPESAS
                                valida02 = wksocios.Cells["C11"].Value.ToString();    //Tem q Ser RECEITAS                                                                                        
                                NomeSocio = wksocios.Cells["B2"].Value.ToString();

                                // Fecha o Sócio
                                packageSocios.Dispose();
                            }

                            //Garante que é uma planilha de Sócio
                            if (valida01.ToUpper().Equals("DESPESAS") && valida02.ToUpper().Equals("RECEITAS"))
                        {
                                var planilhaDest = $"=[" + arqSocio + "]" + nomeMes;

                                worksheet.Cells[lin, 1].Value = NomeSocio; //"Sócio";
                                worksheet.Cells[lin, 2].Formula = planilhaDest + "!$B$12";  //"Valor Total";
                                worksheet.Cells[lin, 3].Formula = planilhaDest + "!$D$11";  //"Recebimento";
                                worksheet.Cells[lin, 4].Formula = $"=IF(B{lin} > 0, C{lin}/B{lin}, 0)";  //"Percentual";
                                worksheet.Cells[lin, 5].Formula = planilhaDest + "!$F$6";  //"Mercadorias Pagas";
                                worksheet.Cells[lin, 6].Formula = planilhaDest + "!$E$20";  //"Sócio Ganhou";
                                worksheet.Cells[lin, 7].Formula = planilhaDest + "!$E$19";  //"Firma Ganhou";
                                lin++; //Vai para o próximo Sócio
                        }

                        }

                        // Formata os Valores
                        for (int linha = 5; linha < lin; linha++)
                        {
                            worksheet.Cells[linha, 1].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                            worksheet.Cells[linha, 2].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                            worksheet.Cells[linha, 3].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                            worksheet.Cells[linha, 4].Style.Numberformat.Format = "0.00%";
                            worksheet.Cells[linha, 5].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                            worksheet.Cells[linha, 6].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                            worksheet.Cells[linha, 7].Style.Numberformat.Format = "_($* #,##0.00_);_($* (#,##0.00);_($* \"-\"??_);_(@_)";
                        }

                        rangeHeader = worksheet.Cells[5, 1, lin, 7];
                        rangeHeader.Style.Font.Size = 16;

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
            //return new DateTime(2024, mes, 1).ToString("MMMM");
            var nomeMes = new DateTime(2024, mes, 1).ToString("MMMM");
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeMes);
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
