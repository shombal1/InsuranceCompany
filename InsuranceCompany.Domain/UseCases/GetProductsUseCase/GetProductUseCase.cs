using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetProductsUseCase;

internal class GetProductUseCase(
    IValidator<GetProductsQuery> validator,
    IGetProductsStorage storage) : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request,cancellationToken);

        return await storage.Get(cancellationToken);
    }
}