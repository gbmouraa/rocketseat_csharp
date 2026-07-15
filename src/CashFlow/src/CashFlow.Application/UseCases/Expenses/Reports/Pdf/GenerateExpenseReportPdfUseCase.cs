using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Repositories.Expense;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public class GenerateExpenseReportPdfUseCase : IGenerateExpenseReportPdfUseCase
    {
        private readonly IExpenseRepository _repository;

        public GenerateExpenseReportPdfUseCase(IExpenseRepository repository)
        {
            _repository = repository;
            
            GlobalFontSettings.FontResolver = new ExpenseReportFontResolver(); // define somente no uso desse useCase
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);

            if (expenses.Count == 0)
                return [];


            return [];
        }
    }
}
