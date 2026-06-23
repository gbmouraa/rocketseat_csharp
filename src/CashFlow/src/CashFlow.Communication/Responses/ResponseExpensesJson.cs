using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Responses
{
    public class ResponseExpensesJson
    {
        public List<ShortExpenseJson> Expenses { get; set; } = [];
    }

    public class ShortExpenseJson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }

    public class ResponseFullExpenseJson
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public EnumPaymentType PaymentType { get; set; }
    }
}
