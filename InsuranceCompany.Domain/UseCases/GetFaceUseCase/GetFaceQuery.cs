using InsuranceCompany.Domain.Models;
using MediatR;

namespace InsuranceCompany.Domain.UseCases.GetFaceUseCase;

public record GetFaceQuery(int Id) : IRequest<Face> { }