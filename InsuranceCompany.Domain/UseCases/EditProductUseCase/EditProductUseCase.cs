using FluentValidation;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.EditProductUseCase;

public class EditProductUseCase(
    IValidator<EditProductQuery> validator,
    IGetFullProduct getFullProductStorage,
    IGetLobsStorage getLobsStorage) : IRequestHandler<EditProductQuery,EditProduct>
{
    public async Task<EditProduct> Handle(EditProductQuery request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var editProduct = new EditProduct();
        
        var product = await getFullProductStorage.Get(request.ProductId, cancellationToken);
        var lobs = await getLobsStorage.Get(cancellationToken);

        return new EditProduct()
        {
            Active = product.Active,
            Description = product.Description,
            Formula = product.Formula,
            Items = product.Items,
            LOBs = lobs,
            LOBId = product.LOBId,
            Name = product.Name,
            NameLOB = product.NameLOB,
            Risks = product.Risks
        };
    }
}