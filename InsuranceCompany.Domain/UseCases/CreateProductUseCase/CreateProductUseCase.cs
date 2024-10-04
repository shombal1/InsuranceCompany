using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateProductUseCase;

internal class CreateProductUseCase(
    IValidator<CreateProductQuery> validator,
    IGetLobsStorage storage
    ) : IRequestHandler<CreateProductQuery, IEnumerable<LOB>>
{
    public async Task<IEnumerable<LOB>> Handle(CreateProductQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request,cancellationToken);

        return await storage.Get(cancellationToken);
    }
}