using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Products.Validator
{
    public class ProductValidator : AbstractValidator<RequestProductJson>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Insira um nome para o produto.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Insira um preco valido.");
            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("Insira a marca do produto.");
        }
    }
}
