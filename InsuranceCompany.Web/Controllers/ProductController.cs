using AutoMapper;
using InsuranceCompany.Web.Models;
using InsuranceCompany.Domain.UseCases.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Api.Controllers;

[Controller]
[Route("[controller]")]
public class ProductController(IMediator mediator, IMapper mapper) : Controller
{
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(mapper.Map<ProductDto>(await mediator.Send(new CreateProductCommand("ui"), cancellationToken)));
    }
}