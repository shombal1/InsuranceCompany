using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CopyProductUseCase;

internal class CopyProductUseCase(IUnitOfWork unitOfWork) : IRequestHandler<CopyProductCommand, int>
{
    public async Task<int> Handle(CopyProductCommand request, CancellationToken cancellationToken)
    {
        var scope = await unitOfWork.StartScope(cancellationToken);

        var getFullProduct = scope.GetStorage<IGetFullProduct>();
        var createProductStorage = scope.GetStorage<ICreateProductStorage>();
        var createProductRiskStorage = scope.GetStorage<ICreateProductRiskStorage>();
        var createItemStorage = scope.GetStorage<ICreateItemStorage>();
        
        var fullProduct = await getFullProduct.Get(request.ProductId, cancellationToken);
        var newProduct = await createProductStorage.Create(
            fullProduct.Active,
            fullProduct.Name,
            fullProduct.Description,
            fullProduct.LOBId,
            fullProduct.Formula,
            cancellationToken);
        
        foreach (var risk in fullProduct.Risks)
        {
            await  createProductRiskStorage.Crete(newProduct.Id,risk.Key, risk.Name, risk.Premium, risk.InsuranceSum, risk.Active,
                cancellationToken);
        }
        
        foreach (ItemBase item in fullProduct.Items)
        {
            await createItemStorage.Create(newProduct.Id,item ,cancellationToken);
        }
        
        await scope.Commit(cancellationToken);

        return newProduct.Id;
    }
}