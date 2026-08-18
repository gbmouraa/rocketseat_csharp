using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public EnumPaymentType PaymentType { get; set; }

        // Definindo o relaciomanento (Doc do EF no site da Microsoft: https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
        public long UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
