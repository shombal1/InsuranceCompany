using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetProducts;

internal class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {

    }
}