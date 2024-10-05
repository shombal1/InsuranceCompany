using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.GetAgentsUseCase;

public class GetAgentsQueryValidator : AbstractValidator<GetAgentsQuery>
{
    public GetAgentsQueryValidator() {}
}