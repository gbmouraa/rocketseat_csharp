using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Extensions;
using CashFlow.Domain.Repositories.Expense;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public class GenerateExpenseReportPdfUseCase : IGenerateExpenseReportPdfUseCase
    {
        private readonly IExpenseRepository _repository;

        public GenerateExpenseReportPdfUseCase(IExpenseRepository repository)
        {
            _repository = repository;

            GlobalFontSettings.FontResolver = new ExpenseReportFontResolver(); // define somente no escopo desse useCase
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);

            if (expenses.Count == 0)
                return [];

            var document = CreateDocument(month);
            var page = CreatePage(document);

            CreateHeader(page);
            CreateTotalSpendSection(page, month, expenses);

            foreach (var expense in expenses)
            {
                var table = CreateExpenseTable(page);

                var row = table.AddRow();
                row.Height = 25;
                row.Borders.Visible = true;

                AddExpenseTitle(row.Cells[0], expense.Title);
                AddHeaderForAmount(row.Cells[3]);

                row = table.AddRow();
                row.Height = 25;
                row.Borders.Visible = true;

                // colocar em uma funcao
                row.Cells[0].AddParagraph(expense.Date.ToString("D"));
                row.Cells[0].Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12 };
                row.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row.Cells[0].Format.LeftIndent = 20;

                // colocar em uma funcao
                row.Cells[1].AddParagraph(expense.Date.ToString("t"));
                row.Cells[1].Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12 };
                row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

                // colocar em uma funcao
                row.Cells[2].AddParagraph(expense.PaymentType.GetDescription());
                row.Cells[2].Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12 };
                row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

                // colocar em uma funcao
                row.Cells[3].AddParagraph($"- {expense.Amount} R$");
                row.Cells[3].Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 14 };
                row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

                row = table.AddRow();
                row.Height = 25;
                row.Borders.Visible = false;
            }

            return RenderDocument(document);
        }

        private Document CreateDocument(DateOnly month)
        {
            var document = new Document();

            document.Info.Title = $"Despesas para {month.ToString("Y")}";
            document.Info.Author = "Gabriel M";

            // define a fonte padrao para o documento
            var style = document.Styles["Normal"];
            style!.Font.Name = FontHelper.RALEWAY_REGULAR;

            return document;
        }

        private Section CreatePage(Document document)
        {
            // pagina
            var section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();

            section.PageSetup.PageFormat = PageFormat.A4;

            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.BottomMargin = 80;
            section.PageSetup.TopMargin = 80;

            return section;
        }

        private void CreateHeader(Section page)
        {
            var table = page.AddTable();
            table.AddColumn();
            table.AddColumn("300"); // 300px

            var assembly = Assembly.GetExecutingAssembly();
            var directoryName = Path.GetDirectoryName(assembly.Location);
            var pathFile = Path.Combine(directoryName!, "Logo", "logo.png");

            var row = table.AddRow();
            row.Cells[0].AddImage(pathFile);
            row.Cells[1].AddParagraph("Hey, Gabriel M.");
            row.Cells[1].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 16 };
            row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
        }

        private void CreateTotalSpendSection(Section page, DateOnly month, List<Expense> expenses)
        {
            var paragraph = page.AddParagraph();
            paragraph.Format.SpaceBefore = "40";
            paragraph.Format.SpaceAfter = "40";
            var title = $"Total gasto em {month.ToString("Y")}";

            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });
            paragraph.AddLineBreak(); // quebra de linha

            var totalExpenses = expenses.Sum(expense => expense.Amount);
            paragraph.AddFormattedText($"{totalExpenses} R$", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });
        }

        private Table CreateExpenseTable(Section page)
        {
            var table = page.AddTable();

            table.AddColumn("195").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn("80").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;

            return table;
        }

        private void AddExpenseTitle(Cell cell, string expenseTitle)
        {
            cell.AddParagraph(expenseTitle);
            cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14 };
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.MergeRight = 2;
            cell.Format.LeftIndent = 20;
        }

        private void AddHeaderForAmount(Cell cell)
        {
            cell.AddParagraph("Valor");
            cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14 };
            cell.VerticalAlignment = VerticalAlignment.Center;
        }

        private byte[] RenderDocument(Document document)
        {
            // cria renderizador para o doc
            var renderer = new PdfDocumentRenderer
            {
                Document = document,
            };

            renderer.RenderDocument();

            using var file = new MemoryStream();
            renderer.PdfDocument.Save(file);// salva o doc na memoria da maquina

            return file.ToArray();
        }
    }
}
