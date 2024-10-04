using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetProductsUseCase;

internal class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {

    }
}