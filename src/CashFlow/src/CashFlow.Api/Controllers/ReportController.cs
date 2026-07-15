using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetExcel([FromHeader] DateOnly month, [FromServices] IGenerateExpenseReportExcelUseCase useCase)
        {
            byte[] file = await useCase.Execute(month);

            if (file.Length > 0)
                return File(file, MediaTypeNames.Application.Octet, "report.xlsx");

            return NoContent();
        }

        [HttpGet("pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPdf([FromQuery] DateOnly month, [FromServices] IGenerateExpenseReportPdfUseCase useCase)
        {
            byte[] file = await useCase.Execute(month);

            if (file.Length > 0)
                return File(file, MediaTypeNames.Application.Pdf, "report.pdf");

            return NoContent();
        }
    }
}
