using System.ComponentModel;
using System.Reflection;

namespace CashFlow.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            // obtem o tipo e campo do Enum. Ex: EnumPaymentType -  EnumPaymentType.CreditCard | "CreditCard"
            var field = value.GetType().GetField(value.ToString());

            if(field == null)
                return value.ToString();

            // obtem o description do enumm
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }
    }
}
