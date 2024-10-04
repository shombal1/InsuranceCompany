namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

public interface IUpdateProductStorage : IStorage
{
    public Task Update(int id,string name, string description, int LOBId, bool active, string formula,
        CancellationToken cancellationToken);
}