using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetContractUseCase;

public class GetContractQueryValidator : AbstractValidator<GetContractQuery>
{
    public GetContractQueryValidator()
    {
        RuleFor((q) => q.Id).NotNull();
    }
}