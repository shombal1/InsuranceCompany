using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateContractUseCase;

public class CreateContractCommandValidator : AbstractValidator<CreateContractCommand>
{
    public CreateContractCommandValidator()
    {
        
    }
}