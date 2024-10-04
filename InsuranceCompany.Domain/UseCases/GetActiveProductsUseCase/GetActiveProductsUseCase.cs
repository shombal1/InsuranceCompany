using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;

internal class GetActiveProductsUseCase(IValidator<GetActiveProductsQuery> validator,IGetActiveProductsStorage storage) : IRequestHandler<GetActiveProductsQuery,IEnumerable<ActiveProduct>>
{
    public async Task<IEnumerable<ActiveProduct>> Handle(GetActiveProductsQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request,cancellationToken);

        return await storage.Get(cancellationToken);
    }
}