using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.CreateContractUseCase;

public class CreateContractUseCase(
    IValidator<CreateContractCommand> validator,
    ILogger<CreateContractUseCase> logger,
    ICreateContractStorage storage) : IRequestHandler<CreateContractCommand, int>
{
    public async Task<int> Handle(CreateContractCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Contract creation started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        Contract contract = new Contract()
        {
            DateCreate = DateTime.Now.ToUniversalTime(),
            DateSign = request.DateSign,
            ProductId = request.ProductId,
            DateBegin = request.DateBegin,
            DateEnd = request.DateEnd,
            Premium = request.Premium,
            InsuranceSum = request.InsuranceSum,
            AgentId = request.AgentId,
            Rate = request.Rate,
            Commission = request.Commission,
            Status = request.Status,
            PolicyHolderId = request.PolicyHolderId,
            InsuredPersonId = request.InsuredPersonId,
            OwnerId = request.OwnerId
        };

        return await storage.Create(contract, cancellationToken);
    }
}