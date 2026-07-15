using CashFlow.Domain.Extensions;
using CashFlow.Domain.Repositories.Expense;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public class GenerateExpenseReportExcelUseCase : IGenerateExpenseReportExcelUseCase
    {
        private readonly IExpenseRepository _repository;

        public GenerateExpenseReportExcelUseCase(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);

            if (expenses.Count == 0)
                return [];

            using var wookbook = new XLWorkbook();
            wookbook.Author = "Gabriel Moura";
            wookbook.Style.Font.FontSize = 12;

            // página excel
            var worksheet = wookbook.AddWorksheet(month.ToString("Y"));
            CreateHeader(worksheet);

            var row = 2;
            foreach (var expense in expenses)
            {
                worksheet.Cell($"A{row}").Value = expense.Title;
                worksheet.Cell($"B{row}").Value = expense.Date;
                worksheet.Cell($"C{row}").Value = expense.PaymentType.GetDescription();

                worksheet.Cell($"D{row}").Value = expense.Amount;
                worksheet.Cell($"D{row}").Style.NumberFormat.Format = "- R$ #,##0.00";

                worksheet.Cell($"E{row}").Value = expense.Description;

                row++;
            }

            worksheet.Columns().AdjustToContents();

            var file = new MemoryStream(); // meio que é uma classe para salvar arquivos temporariamente em memoria
            wookbook.SaveAs(file);

            return file.ToArray();
        }

        private static void CreateHeader(IXLWorksheet worksheet)
        {
            worksheet.Cell("A1").Value = "Título";
            worksheet.Cell("B1").Value = "Data";
            worksheet.Cell("C1").Value = "Tipo Pagamento";
            worksheet.Cell("D1").Value = "Total";
            worksheet.Cell("E1").Value = "Descrição";

            worksheet.Cells("A1:E1").Style.Font.Bold = true;
            worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.Aqua;

            worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        }
    }
}
