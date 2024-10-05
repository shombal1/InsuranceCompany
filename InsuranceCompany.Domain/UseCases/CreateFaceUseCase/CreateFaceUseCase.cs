using AutoMapper;
using FluentValidation;
using InsuranceCompany.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.CreateFaceUseCase;

public class CreateFaceUseCase(
    IValidator<CreateFaceCommand> validator,
    ILogger<CreateFaceUseCase> logger,
    IMapper mapper,
    ICreateFaceStorage storage) : IRequestHandler<CreateFaceCommand, int>
{
    public async Task<int> Handle(CreateFaceCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Face creation started.");

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        Face face = mapper.Map<Face>(request);

        return await storage.Create(face, cancellationToken);
    }
}