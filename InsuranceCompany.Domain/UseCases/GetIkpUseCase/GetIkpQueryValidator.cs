using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetIkpUseCase;

public class GetIkpQueryValidator : AbstractValidator<GetIkpQuery>
{
    public GetIkpQueryValidator()
    {
        RuleFor((q) => q.Id).NotNull();
    }
}