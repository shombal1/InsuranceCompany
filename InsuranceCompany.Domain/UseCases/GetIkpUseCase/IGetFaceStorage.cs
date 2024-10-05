using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetIkpUseCase;

public interface IGetIkpStorage
{
    public Task<Ikp> Get(int id, CancellationToken cancellationToken);
}