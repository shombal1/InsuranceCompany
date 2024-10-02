using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.CreateContractUseCase;

public interface ICreateContractStorage
{
    public Task<int> Create(Contract contract, CancellationToken cancellationToken);
}