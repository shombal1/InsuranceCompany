using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetFaceUseCase;

public interface IGetFaceStorage
{
    public Task<Face> Get(int id, CancellationToken cancellationToken);
}