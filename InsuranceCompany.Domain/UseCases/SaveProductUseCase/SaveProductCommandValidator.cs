using FluentValidation;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

public class SaveProductCommandValidator: AbstractValidator<SaveProductCommand>
{
    public SaveProductCommandValidator(IValidator<InputBoxCommand> v1,IValidator<ItemComboBoxCommand> v2,ILogger<SaveProductCommandValidator> logger)
    {
        // RuleFor(x => x.Name)
        //     .NotEmpty().WithMessage("Empty")
        //     .MaximumLength(50).WithMessage("too long");
        //
        // RuleFor(x => x.Description)
        //     .NotEmpty().WithMessage("Empty")
        //     .MaximumLength(100).WithMessage("too long");

        // RuleFor(x => x.Items)
        //     .ForEach(item =>
        //     {
        //         // var validator = validators.FirstOrDefault(
        //         //     v => v.GetType().GetGenericArguments().First() == item.GetType());
        //         //
        //         // logger.LogInformation(validators.ToArray().Length.ToString());
        //         //
        //         // if (validator is not null)
        //         // {
        //         //     item.SetValidator(validator);
        //         }
        //     });
        logger.LogInformation("JITOOY " + (v1 is null).ToString());
        // RuleFor(x => x.Risks)
        //     .NotNull().WithMessage("Risks cannot be null.")
        //     .Must(risks => risks.Count > 0).WithMessage("Risks must contain at least one risk.")
        //     .ForEach(risk => risk.SetValidator(new ProductRiskCommandValidator()));

        // RuleFor(x => x.Formula)
        //     .NotEmpty().WithMessage("Empty");
    }
}