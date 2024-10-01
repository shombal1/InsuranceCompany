using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class SaveProductUseCase(IValidator<SaveProductCommand> validator,ILogger<SaveProductUseCase> logger) : IRequestHandler<SaveProductCommand,Unit>
{ 
    public async Task<Unit> Handle(SaveProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(validator.Validate(request).IsValid.ToString());
        await validator.ValidateAndThrowAsync(request,cancellationToken);
            logger.LogInformation("fe");
        return new Unit();
    }
}