using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateProductUseCase;

public class CreateProductUseCase(
    IValidator<CreateProductQuery> validator,
    IGetLobsStorage storage
    ) : IRequestHandler<CreateProductQuery, IEnumerable<Lob>>
{
    public async Task<IEnumerable<Lob>> Handle(CreateProductQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request,cancellationToken);

        return await storage.Get(cancellationToken);
    }
}