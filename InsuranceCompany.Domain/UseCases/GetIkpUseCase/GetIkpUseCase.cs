using FluentValidation;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetFaceUseCase;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.GetIkpUseCase;

public class GetIkpUseCase(
    IValidator<GetIkpQuery> validator,
    ILogger<GetIkpUseCase> logger,
    IGetIkpStorage storage) : IRequestHandler<GetIkpQuery, Ikp>
{
    public async Task<Ikp> Handle(GetIkpQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Face loading started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await storage.Get(request.Id, cancellationToken);
    }
}