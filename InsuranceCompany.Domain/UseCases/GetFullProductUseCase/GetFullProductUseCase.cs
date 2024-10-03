using FluentValidation;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetProducts;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetFullProductUseCase;

public class GetFullProductUseCase(
    IValidator<GetFullProductQuery> validator,
    IGetFullProduct getFullProductStorage) : IRequestHandler<GetFullProductQuery,FullProduct>
{
    public async Task<FullProduct> Handle(GetFullProductQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await getFullProductStorage.Get(request.ProductId, cancellationToken);
    }
}