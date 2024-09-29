using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.CreateProduct;

internal class CreateProductUseCase(
    IValidator<CreateProductCommand> validator,
    ICreateProductStorage storage) : IRequestHandler<CreateProductCommand, Product>
{
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request,cancellationToken);

        return await storage.Create(request.Name);
    }
}