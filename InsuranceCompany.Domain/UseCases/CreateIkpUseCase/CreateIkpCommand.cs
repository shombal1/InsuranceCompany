using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateIkpUseCase;

public record CreateIkpCommand : IRequest<int>
{
    public string Name { get; set; }
}