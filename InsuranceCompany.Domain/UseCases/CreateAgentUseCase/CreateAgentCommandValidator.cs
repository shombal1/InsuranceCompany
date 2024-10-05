using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateAgentUseCase;

public class CreateAgentCommandValidator : AbstractValidator<CreateAgentCommand>
{
    public CreateAgentCommandValidator()
    {
        RuleFor((c) => c.FaceId).NotNull();
        RuleFor((c) => c.IKPId).NotNull();
        RuleFor((c) => c.StatusId).NotNull();
    }
}