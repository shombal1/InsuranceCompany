using AutoMapper;
using InsuranceCompany.Domain.Models;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;
using InsuranceCompany.Domain.UseCases.GetAgentsUseCase;
using InsuranceCompany.Web.Models.Agent;
using InsuranceCompany.Web.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("buy-product")]
public class BuyProductController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() // url: GET /buy-product/
    {
        return View(new GetActiveProductsDto()
        {
            Products = (await mediator.Send(new GetActiveProductsQuery()))
                .Select(mapper.Map<GetActiveProductDto>)
                .ToList()
        });
    }

    [HttpGet]
    [Route("edit/{productId}")]
    public async Task<IActionResult> Edit(int productId) // url: GET /buy-product/edit/{id}
    {
        var agents = await mediator.Send(new GetAgentsQuery());

        var editProductDto = mapper.Map<EditProductDto>(await mediator.Send(new EditProductQuery(productId)));

        editProductDto.AgentsDto = agents
            .Select(mapper.Map<GetAgentDto>)
            .ToList();

        return View(editProductDto);
    }
}