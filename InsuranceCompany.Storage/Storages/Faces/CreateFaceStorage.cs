using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateFaceUseCase;
using InsuranceCompany.Storage.Entities;

namespace InsuranceCompany.Storage.Storages.Faces;

internal class CreateFaceStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : ICreateFaceStorage
{
    public async Task<int> Create(Face face, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<FaceEntity>(face);

        var entityEntry = await dbContext.Faces.AddAsync(entity, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return entityEntry.Entity.Id;
    }
}