using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateContractUseCase;

public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
        RuleFor((c) => c.Status).NotNull();
        RuleFor((c) => c.AgentId).NotNull();
        RuleFor((c) => c.ProductId).NotNull();
    }
}