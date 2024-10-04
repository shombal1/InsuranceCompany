using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.CreateFaceUseCase;

public interface ICreateFaceStorage
{
    public Task<int> Create(Face face, CancellationToken cancellationToken);
}