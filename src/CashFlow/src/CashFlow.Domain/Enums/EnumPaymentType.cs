using System.ComponentModel;

namespace CashFlow.Domain.Enums
{
    public enum EnumPaymentType
    {
        [Description("Dinheiro")] Cash = 0,
        [Description("Cartão de Crédito")] CreditCard = 1,
        [Description("Cartão de Débito")] DebitCard = 2,
        [Description("Transação Eletrônica")] EletronicTransation = 3,
    }
}
