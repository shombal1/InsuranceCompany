using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.GetContractUseCase;

public class GetContractUseCase(
    IValidator<GetContractQuery> validator,
    ILogger<GetContractUseCase> logger,
    IGetContractStorage storage) : IRequestHandler<GetContractQuery, Contract>
{
    public async Task<Contract> Handle(GetContractQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Contract loading started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await storage.Get(request.Id, cancellationToken);
    }
}