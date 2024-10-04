using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateContractUseCase;
using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InsuranceCompany.Storage.Storages.Contracts;

internal class CreateContractStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : ICreateContractStorage
{
    public async Task<int> Create(Contract contract, CancellationToken cancellationToken)
    {
        ContractEntity entity = mapper.Map<ContractEntity>(contract);

        EntityEntry<ContractEntity> entityEntry = await dbContext.Contracts.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity.Id;
    }
}