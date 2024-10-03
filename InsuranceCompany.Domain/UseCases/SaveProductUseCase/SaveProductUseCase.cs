using System.Text.Json;
using AutoMapper;
using FluentValidation;
using InsuranceCompany.Domain.Models.Items;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class SaveProductUseCase(
    IValidator<SaveProductCommand> validator,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<SaveProductCommand,Unit>
{ 
    public async Task<Unit> Handle(SaveProductCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request,cancellationToken);

        var scope = await unitOfWork.StartScope(cancellationToken);

        var createProductStorage = scope.GetStorage<ICreateProductStorage>();
        var createProductRiskStorage = scope.GetStorage<ICreateProductRiskStorage>();
        var createItemStorage = scope.GetStorage<ICreateItemStorage>();

        var product = await createProductStorage.Create(
            request.Name, request.Description, request.LOBId,request.Formula,cancellationToken);

        foreach (var risk in request.Risks)
        {
           await  createProductRiskStorage.Crete(product.Id,risk.Key, risk.Name, risk.Premium, risk.InsuranceSum, risk.Active,
                cancellationToken);
        }
        
        foreach (ItemBaseCommand item in request.Items)
        {
            await createItemStorage.Create(product.Id,mapper.Map<ItemBase>(item) ,cancellationToken);
        }
        
        await scope.Commit(cancellationToken);
        
        return new Unit();
    }
}