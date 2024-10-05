using AutoMapper;
using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.GetAgentUseCase;

public class GetAgentUseCase(
    IValidator<GetAgentQuery> validator,
    ILogger<GetAgentUseCase> logger,
    IMapper mapper,
    IGetAgentStorage storage) : IRequestHandler<GetAgentQuery, Agent>
{
    public async Task<Agent> Handle(GetAgentQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Agent creation started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await storage.Get(request.Id, cancellationToken);
    }
}