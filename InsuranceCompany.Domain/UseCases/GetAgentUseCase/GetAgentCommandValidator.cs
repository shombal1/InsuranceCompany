using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetAgentUseCase;

public class GetAgentCommandValidator : AbstractValidator<GetAgentQuery>
{
    public GetAgentCommandValidator()
    {
        RuleFor((c) => c.Id).NotNull();
    }
}