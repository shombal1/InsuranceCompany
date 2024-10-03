using System.Text.Json;
using AutoMapper;
using InsuranceCompany.Domain.UseCases.CopyProductUseCase;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using InsuranceCompany.Domain.UseCases.GetFullProductUseCase;
using InsuranceCompany.Domain.UseCases.GetProducts;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Web.Models;
using InsuranceCompany.Web.Models.Item;
using InsuranceCompany.Web.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class ProductController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() // url: GET /product/
    {
        // логика получения всех продуктов и передача данных в View
        return View(new GetProductsDto()
        {
            Products = (await mediator.Send(new GetProductsQuery())).Select(mapper.Map<GetProductDto>).ToList()
        });
    }

    // [HttpGet]
    // [Route("buy")]
    // public async Task<IActionResult> GetActiveProduct()
    // {
    //     
    // }
    
    [HttpGet]
    [Route("create")]
    public async Task<IActionResult> Create() // url: GET /product/create
    {
        return View(new CreateProductDto()
        {
            LobsDto = (await mediator.Send(new CreateProductQuery())).Select(mapper.Map<LOBDto>).ToList()
        });
    }

    [HttpPost]
    [Route("copy")]
    public async Task<IActionResult> Copy(int productId)
    {
        return Ok(await mediator.Send(new CopyProductCommand(productId)));
    }

    [HttpPost]
    [Route("save")]
    public async Task<IActionResult> Save([FromBody] SaveProductDto saveProductDto) // url: POST /product/save
    {
        try
        {
            var command = mapper.Map<SaveProductCommand>(saveProductDto);
            int id = await mediator.Send(command);
            return Ok(id);
        }
        catch (Exception e)
        {
            return Ok(e.Message);
        }
    }

    [HttpGet]
    [Route("edit")]
    public async Task<IActionResult> Edit(int productId) // url: GET /product/edit/{id}
    {
        // логика получения конкретного продукта и всех его связей

        return View(mapper.Map<GetFullProductDto>(await mediator.Send(new GetFullProductQuery(productId))));
    }
    //
    // [HttpPut]
    // public IActionResult Update(int id, [FromBody] UpdateProductDto updateProductDto) // url: POST /product/update/{id}
    // {
    //     // логика получения конкретного продукта и его одновления
    //     return Ok("success");
    // }
}