using InsuranceCompany.Domain.Enum;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateFaceUseCase;

public record CreateFaceCommand : IRequest<int>
{
    public FaceType Type { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Lastname { get; set; }
    public DateTime DateBirth { get; set; }
    public string Name { get; set; }
    public int INN { get; set; }
}