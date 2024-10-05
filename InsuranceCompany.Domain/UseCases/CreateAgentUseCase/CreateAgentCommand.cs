using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateAgentUseCase;

public record CreateAgentCommand : IRequest<int>
{
    public DateTimeOffset DateCreate { get; set; }
    public DateTimeOffset? DateBegin { get; set; }
    public DateTimeOffset? DateEnd { get; set; }
    public int FaceId { get; set; }
    public int IKPId { get; set; }
    public int StatusId { get; set; }
}