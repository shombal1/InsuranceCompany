using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.CreateIkpUseCase;

public interface ICreateIkpStorage
{
    public Task<int> Create(Ikp ikp, CancellationToken cancellationToken);
}