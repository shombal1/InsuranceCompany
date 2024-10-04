using AutoMapper;
using FluentValidation;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.CreateIkpUseCase;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InsuranceCompany.Domain.UseCases.CreateFaceUseCase
{
    public class CreateIkpUseCase(
        IValidator<CreateIkpCommand> validator,
        ILogger<CreateIkpUseCase> logger,
        IMapper mapper,
        ICreateIkpStorage storage) : IRequestHandler<CreateIkpCommand, int>
    {
        public async Task<int> Handle(CreateIkpCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Face creation started.");

            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var ikp = mapper.Map<Ikp>(request);

            return await storage.Create(ikp, cancellationToken);
        }
    }
}