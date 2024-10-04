using FluentValidation;

namespace InsuranceCompany.Domain.UseCases.CreateFaceUseCase;

public class CreateFaceCommandValidator : AbstractValidator<CreateFaceCommand>
{
    public CreateFaceCommandValidator()
    {
        RuleFor((c) => c.Type).NotNull();
    }
}