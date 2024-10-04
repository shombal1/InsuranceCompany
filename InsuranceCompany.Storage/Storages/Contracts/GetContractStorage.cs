using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetContractUseCase;

namespace InsuranceCompany.Storage.Storages.Contracts;

internal class GetContractStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : IGetContractStorage
{
    public async Task<Contract> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Contracts.FindAsync(id);

        var contract = mapper.Map<Contract>(entity);

        return contract;
    }
}