using AutoMapper;
using FluentValidation;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetAgentUseCase;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.GetAgentsUseCase;

public class GetAgentsUseCase(
    IValidator<GetAgentsQuery> validator,
    ILogger<GetAgentsUseCase> logger,
    IMapper mapper,
    IGetAgentStorage storage) : IRequestHandler<GetAgentsQuery, IEnumerable<Agent>>
{
    public async Task<IEnumerable<Agent>> Handle(GetAgentsQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        return await storage.Get(cancellationToken);
    }
}