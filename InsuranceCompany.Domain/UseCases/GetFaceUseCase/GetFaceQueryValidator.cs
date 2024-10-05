using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetFaceUseCase;

public class GetFaceQueryValidator : AbstractValidator<GetFaceQuery>
{
    public GetFaceQueryValidator()
    {
        RuleFor((q) => q.Id).NotNull();
    }
}