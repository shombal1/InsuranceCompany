using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateFaceUseCase;
using InsuranceCompany.Storage.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InsuranceCompany.Storage.Storages.Faces;

internal class CreateFaceStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : ICreateFaceStorage
{
    public async Task<int> Create(Face face, CancellationToken cancellationToken)
    {
        FaceEntity entity = mapper.Map<FaceEntity>(face);

        EntityEntry<FaceEntity> entityEntry = await dbContext.Faces.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity.Id;
    }
}