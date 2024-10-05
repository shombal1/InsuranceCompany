using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetContractUseCase;

public interface IGetContractStorage
{
    public Task<Contract> Get(int id, CancellationToken cancellationToken);
}