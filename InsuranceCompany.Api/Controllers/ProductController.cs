using AutoMapper;
using InsuranceCompany.Api.Models;
using InsuranceCompany.Domain.UseCases.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(mapper.Map<ProductDto>(await mediator.Send(new CreateProductCommand("ui"), cancellationToken)));
    }
}