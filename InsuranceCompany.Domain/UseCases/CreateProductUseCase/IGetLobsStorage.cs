using InsuranceCompany.Domain.Models;

namespace InsuranceCompany.Domain.UseCases.CreateProductUseCase;

public interface IGetLobsStorage
{
    public Task<IEnumerable<LOB>> Get(CancellationToken cancellationToken);
}