using AutoMapper;
using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.CreateAgentUseCase;

public class CreateAgentUseCase(
    IValidator<CreateAgentCommand> validator,
    ILogger<CreateAgentUseCase> logger,
    IMapper mapper,
    ICreateAgentStorage storage) : IRequestHandler<CreateAgentCommand, int>
{
    public async Task<int> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Agent creation started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        Agent agent = mapper.Map<Agent>(request);

        return await storage.Create(agent, cancellationToken);
    }
}