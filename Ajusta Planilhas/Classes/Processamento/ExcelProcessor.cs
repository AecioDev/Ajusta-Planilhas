using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Globalization;

namespace Gestao_Planilhas.Classes.Processamento
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

        public string GeraResumoSocios(string pastaPadrao, string empresa)
        {
            List<string> listaPlanilhas = new List<string>();
            string caminhoResumo = pastaPadrao + @"\RESUMO_SOCIOS_" + empresa + "_" + DateTime.Now.ToString("G")
                .Replace("/", "")
                .Replace(":", "")
                .Replace(" ", "")
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
                        worksheet.Cells["F4"].Value = "Firma Ganhou";
                        worksheet.Cells["G4"].Value = "Sócio Ganhou";

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
                            string NomeArqSocio = "";
                            string? valida01 = "";
                            string? valida02 = "";

                            //Dados do Sócio    
                            string? NomeSocio = "";
                            decimal Valtot = 0;
                            decimal ValReceb = 0;
                            decimal MercPagas = 0;
                            decimal ValSocio = 0;
                            decimal ValFirma = 0;

                            // Carrega o arquivo Excel
                            FileInfo fileSocio = new FileInfo(arqSocio);

                            NomeArqSocio = fileSocio.Name;

                            using (ExcelPackage packageSocios = new ExcelPackage(fileSocio))
                            {
                                // Busca os Dados do Sócio
                                var wksocios = packageSocios.Workbook.Worksheets[nomeMes];

                                // Desbloqueie a planilha
                                wksocios.Protection.IsProtected = false;

                                valida01 = wksocios.Cells["A13"].Value == null ? "" : wksocios.Cells["A13"].Value.ToString(); // Deve ser "DESPESAS"
                                valida02 = wksocios.Cells["C11"].Value == null ? "" : wksocios.Cells["C11"].Value.ToString(); // Deve ser "RECEITAS"
                                if (string.IsNullOrEmpty(valida01)) { valida01 = ""; }
                                if (string.IsNullOrEmpty(valida02)) { valida02 = ""; }

                                if (valida01.ToUpper().Equals("DESPESAS") && valida02.ToUpper().Equals("RECEITAS"))
                                {
                                    NomeSocio = wksocios.Cells["B2"].Value == null ? "" : wksocios.Cells["B2"].Value.ToString();
                                    Valtot = wksocios.Cells["B12"].Value == null ? 0 : Convert.ToDecimal(wksocios.Cells["B12"].Value);
                                    ValReceb = wksocios.Cells["D11"].Value == null ? 0 : Convert.ToDecimal(wksocios.Cells["D11"].Value);
                                    MercPagas = wksocios.Cells["F6"].Value == null ? 0 : Convert.ToDecimal(wksocios.Cells["F6"].Value);
                                    ValFirma = wksocios.Cells["E19"].Value == null ? 0 : Convert.ToDecimal(wksocios.Cells["E19"].Value);
                                    ValSocio = wksocios.Cells["E20"].Value == null ? 0 : Convert.ToDecimal(wksocios.Cells["E20"].Value);
                                }

                                // Bloqueie a planilha novamente (opcional)
                                wksocios.Protection.IsProtected = true;

                                // Fecha o Sócio
                                packageSocios.Dispose();
                            }

                            if (string.IsNullOrEmpty(valida01)) { valida01 = ""; }
                            if (string.IsNullOrEmpty(valida02)) { valida02 = ""; }
                            if (string.IsNullOrEmpty(NomeSocio)) { NomeSocio = ""; }

                            //Garante que é uma planilha de Sócio
                            if (valida01.ToUpper().Equals("DESPESAS") && valida02.ToUpper().Equals("RECEITAS"))
                            {
                                //Dados com Fórmulas
                                //var planilhaDest = @$"='" + pastaPadrao + @"\[" + NomeArqSocio + "]" + nomeMes;

                                //worksheet.Cells[lin, 1].Value = NomeSocio; //"Sócio";
                                //worksheet.Cells[lin, 2].Formula = planilhaDest + "'!$B$12";  //"Valor Total";
                                //worksheet.Cells[lin, 3].Formula = planilhaDest + "'!$D$11";  //"Recebimento";
                                //worksheet.Cells[lin, 4].Formula = $"=IF(B{lin} > 0, C{lin}/B{lin}, 0)";  //"Percentual";
                                //worksheet.Cells[lin, 5].Formula = planilhaDest + "'!$F$6";  //"Mercadorias Pagas";
                                //worksheet.Cells[lin, 6].Formula = planilhaDest + "'!$E$20";  //"Sócio Ganhou";
                                //worksheet.Cells[lin, 7].Formula = planilhaDest + "'!$E$19";  //"Firma Ganhou";

                                //Dados Estáticos

                                //"Sócio";
                                worksheet.Cells[lin, 1].Value = NomeSocio;
                                worksheet.Cells[lin, 1].Style.Font.Size = 16;
                                worksheet.Cells[lin, 1].Style.Font.Bold = true;

                                //"Valor Total";
                                worksheet.Cells[lin, 2].Value = Valtot;
                                worksheet.Cells[lin, 2].Style.Font.Size = 16;
                                worksheet.Cells[lin, 2].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                                //"Recebimento";
                                worksheet.Cells[lin, 3].Value = ValReceb;
                                worksheet.Cells[lin, 3].Style.Font.Size = 16;
                                worksheet.Cells[lin, 3].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                                //"Percentual";
                                worksheet.Cells[lin, 4].Formula = $"=IF(B{lin} > 0, C{lin}/B{lin}, 0)";
                                worksheet.Cells[lin, 4].Style.Font.Size = 16;
                                worksheet.Cells[lin, 4].Style.Numberformat.Format = "0.00%";

                                //"Mercadorias Pagas";
                                worksheet.Cells[lin, 5].Value = MercPagas;
                                worksheet.Cells[lin, 5].Style.Font.Size = 16;
                                worksheet.Cells[lin, 5].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                                //"Firma Ganhou";
                                worksheet.Cells[lin, 6].Value = ValFirma;
                                worksheet.Cells[lin, 6].Style.Font.Size = 16;
                                worksheet.Cells[lin, 6].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                                //"Sócio Ganhou";
                                worksheet.Cells[lin, 7].Value = ValSocio;
                                worksheet.Cells[lin, 7].Style.Font.Size = 16;
                                worksheet.Cells[lin, 7].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                                lin++; //Vai para o próximo Sócio
                            }

                        }

                        lin++; //Pula uma Linha para o Total 
                        var linha = lin - 1;
                        var linhaf = linha.ToString();

                        // Linha de Somatórios
                        worksheet.Cells[lin, 1].Value = "TOTAL";
                        worksheet.Cells[lin, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        //"Valor Total";
                        worksheet.Cells[lin, 2].Formula = $"=SUM(B" + 5 + ":B" + linhaf + ")";
                        worksheet.Cells[lin, 2].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                        //"Recebimento";
                        worksheet.Cells[lin, 3].Formula = $"=SUM(C" + 5 + ":C" + linhaf + ")";
                        worksheet.Cells[lin, 3].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                        //"Percentual";
                        worksheet.Cells[lin, 4].Formula = $"=IF(B" + linhaf + " > 0, C" + linhaf + "/B" + linhaf + ", 0)";
                        worksheet.Cells[lin, 4].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                        //"Mercadorias Pagas";
                        worksheet.Cells[lin, 5].Formula = $"=SUM(E" + 5 + ":E" + linhaf + ")";
                        worksheet.Cells[lin, 5].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                        //"Firma Ganhou";
                        worksheet.Cells[lin, 6].Formula = $"=SUM(F" + 5 + ":F" + linhaf + ")";
                        worksheet.Cells[lin, 6].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                        //"Sócio Ganhou";
                        worksheet.Cells[lin, 7].Formula = $"=SUM(G" + 5 + ":G" + linhaf + ")";
                        worksheet.Cells[lin, 7].Style.Numberformat.Format = "_(R$* #,##0.00_);_($* (#,##0.00);_(R$* \"-\"??_);_(@_)";

                        //Range Estilo do Totalizador
                        rangeHeader = worksheet.Cells["A" + lin + ":G" + lin];
                        rangeHeader.Style.Font.Size = 16;
                        rangeHeader.Style.Font.Bold = true;
                        rangeHeader.Style.Font.Color.SetColor(Color.Blue);

                        //Adicionando Fórmulas
                        rangeHeader = worksheet.Cells["A" + 5 + ":G" + linhaf];

                        var border = rangeHeader.Style.Border;

                        border.Left.Style = ExcelBorderStyle.Thin;
                        border.Right.Style = ExcelBorderStyle.Thin;
                        border.Top.Style = ExcelBorderStyle.Thin;
                        border.Bottom.Style = ExcelBorderStyle.Thin;

                        border.BorderAround(ExcelBorderStyle.Medium);

                    }

                    // Salva o arquivo
                    package.SaveAs(new FileInfo(caminhoResumo));
                }

                MessageBox.Show("RESUMO GERADO com sucesso!!!", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return caminhoResumo;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar a planilha de Resumo: {ex.Message}", "Atenção!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return "";
            }

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
