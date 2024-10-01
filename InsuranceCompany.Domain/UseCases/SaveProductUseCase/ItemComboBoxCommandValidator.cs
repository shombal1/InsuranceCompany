using FluentValidation;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class ItemComboBoxCommandValidator : AbstractValidator<ItemComboBoxCommand>
{
    public ItemComboBoxCommandValidator(ILogger<ItemComboBoxCommandValidator> logger)
    {
        logger.LogInformation("EF");
        RuleFor(c => c.Description).NotEmpty();
    }
}