using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.GetFaceUseCase;

namespace InsuranceCompany.Storage.Storages.Contracts;

internal class GetFaceStorage(InsuranceCompanyDbContext dbContext, IMapper mapper) : IGetFaceStorage
{
    public async Task<Face> Get(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Faces.FindAsync(id);

        var face = mapper.Map<Face>(entity);

        return face;
    }
}