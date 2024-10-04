using System.Text.Json;
using AutoMapper;
using InsuranceCompany.Domain.UseCases.CopyProductUseCase;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;
using InsuranceCompany.Domain.UseCases.GetProductsUseCase;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Web.Models;
using InsuranceCompany.Web.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        return View(mapper.Map<EditProductDto>(await mediator.Send(new EditProductQuery(productId))));
    }
}