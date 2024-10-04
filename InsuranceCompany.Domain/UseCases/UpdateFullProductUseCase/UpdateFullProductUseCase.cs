using AutoMapper;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;

internal class UpdateFullProductUseCase(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateFullProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateFullProductCommand request, CancellationToken cancellationToken)
    {
        var scope = await unitOfWork.StartScope(cancellationToken);

        var getFullProductStorage = scope.GetStorage<IGetFullProduct>();
        var getIdItemsStorage = scope.GetStorage<IGetIdItemsStorage>();
        var updateProductStorage = scope.GetStorage<IUpdateProductStorage>();
        var deleteItemStorage = scope.GetStorage<IDeleteItemStorage>();
        var deleteProductRiskStorage = scope.GetStorage<IDeleteProductRiskStorage>();
        var createItemStorage = scope.GetStorage<ICreateItemStorage>();
        var createProductRiskStorage = scope.GetStorage<ICreateProductRiskStorage>();

        var product = await getFullProductStorage.Get(request.ProductId, cancellationToken);

        await updateProductStorage.Update(request.ProductId, request.Name, request.Description, request.LOBId,
            request.Active, request.Formula, cancellationToken);

        await deleteItemStorage.Delete( await getIdItemsStorage.Get(request.ProductId,cancellationToken), cancellationToken);
        await deleteProductRiskStorage.Delete(product.Risks.Select(i => i.Id), cancellationToken);

        foreach (var item in request.Items)
        {
            await createItemStorage.Create(request.ProductId, mapper.Map<ItemBase>(item), cancellationToken);
        }

        foreach (var risk in request.Risks)
        {
            await createProductRiskStorage.Crete(request.ProductId, risk.Key, risk.Name, risk.Premium,
                risk.InsuranceSum, risk.Active, cancellationToken);
        }

        await scope.Commit(cancellationToken);

        return new Unit();
    }
}