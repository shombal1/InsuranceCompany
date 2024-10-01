using System.Text.Json;
using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using InsuranceCompany.Domain.UseCases.GetProducts;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Web.Models;
using InsuranceCompany.Web.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class ProductController(IMediator mediator, IMapper mapper,ILogger<HomeController> logger) : Controller
{

    [HttpGet]
    [Route("index")]
    public async Task<IActionResult> Index() // url: GET /product/
    {
        // логика получения всех продуктов и передача данных в View
        return View(new GetProductsDto()
        {
            Products = (await mediator.Send(new GetProductsQuery())).Select(mapper.Map<ProductDto>).ToList()
        });
    }

    public async Task<IActionResult> Create() // url: GET /product/create
    {
        return View(new CreateProductDto()
        {
            LobsDto = (await mediator.Send(new CreateProductQuery())).Select(mapper.Map<LobDto>).ToList()
        });
    }

    [HttpGet]
    [Route("kl")]
    public IActionResult Save() // url: POST /product/save
     {
        mediator.Send(new SaveProductCommand("test", "D", 3,
            [new InputBoxCommand(), new ItemComboBoxCommand(){Description = ""}], [new ProductRiskCommand()], ""));

        return Ok("success");
    }

    public IActionResult Edit(int id) // url: GET /product/edit/{id}
    {
        // логика получения конкретного продукта и всех его связей

        return View(new GetProductDto());
    }

    [HttpPut]
    public IActionResult Update(int id, [FromBody] UpdateProductDto updateProductDto) // url: POST /product/update/{id}
    {
        // логика получения конкретного продукта и его одновления
        return Ok("success");
    }
}