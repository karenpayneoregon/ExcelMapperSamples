using FluentValidation;
using ValidationLibrary;

namespace SampleApp4.Models;
/// <summary>
/// Validation rules for products model
/// </summary>
public class ProductsValidator : AbstractValidator<Products>
{
    public ProductsValidator()
    {
        RuleFor(p => p.ProductName).NoNoneAsciiCharacters();
        RuleFor(p => p.CategoryName).NoNoneAsciiCharacters();
        RuleFor(p => p.QuantityPerUnit).NotEmpty();
        RuleFor(p => p.Supplier).NoNoneAsciiCharacters();
        RuleFor(p => p.ProductID).GreaterThan(0);
    }
}
