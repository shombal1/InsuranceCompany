using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.GetFaceUseCase;

public class GetFaceUseCase(
    IValidator<GetFaceQuery> validator,
    ILogger<GetFaceUseCase> logger,
    IGetFaceStorage storage) : IRequestHandler<GetFaceQuery, Face>
{
    public async Task<Face> Handle(GetFaceQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Face loading started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await storage.Get(request.Id, cancellationToken);
    }
}