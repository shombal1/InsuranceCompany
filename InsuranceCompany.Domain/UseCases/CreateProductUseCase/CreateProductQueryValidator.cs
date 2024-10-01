using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateProductUseCase;

public class CreateProductQueryValidator : AbstractValidator<CreateProductQuery>
{
    public CreateProductQueryValidator()
    {
        
    }
}