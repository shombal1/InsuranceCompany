using FluentValidation;
using InsuranceCompany.Domain.Models.Items;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.SaveProductUseCase;

internal class SaveProductCommandValidator: AbstractValidator<SaveProductCommand>
{
    public SaveProductCommandValidator(IValidator<CreateItemInputBoxCommand> inputBoxValidator,
        IValidator<CreateItemComboBoxCommand> comboBoxValidator)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Empty")
            .MaximumLength(50).WithMessage("too long");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Empty")
            .MaximumLength(100).WithMessage("too long");
        
        RuleForEach(x => x.Items)
            .Custom((item,context) =>
            {
                switch (item)
                {
                    case CreateItemInputBoxCommand inputBoxCommand:
                        inputBoxValidator.Validate(inputBoxCommand);
                        break;
                    case CreateItemComboBoxCommand inputBoxCommand:
                        comboBoxValidator.Validate(inputBoxCommand);
                        break;
                    default:
                        context.AddFailure("unrecognized item ");
                        break;
                }
            });
        
        RuleFor(x => x.Risks)
            .NotNull().WithMessage("Empty")
            .ForEach(risk => risk.SetValidator(new CreateProductRiskCommandValidator()));
    }
}