using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;

public interface IGetActiveProductsStorage : IStorage
{
    public Task<IEnumerable<ActiveProduct>> Get(CancellationToken cancellationToken);
}