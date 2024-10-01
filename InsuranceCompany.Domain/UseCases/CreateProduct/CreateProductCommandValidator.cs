using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateProduct;

internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithErrorCode("Empty")
            .MaximumLength(50).WithErrorCode("Too long");
    }
}