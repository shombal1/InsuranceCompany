using System.Text.Json;
using AutoMapper;
using InsuranceCompany.Domain.UseCases.CopyProductUseCase;
using InsuranceCompany.Domain.UseCases.CreateProductUseCase;
using InsuranceCompany.Domain.UseCases.EditProductUseCase;
using InsuranceCompany.Domain.UseCases.GetActiveProductsUseCase;
using InsuranceCompany.Domain.UseCases.GetProductsUseCase;
using InsuranceCompany.Domain.UseCases.SaveProductUseCase;
using InsuranceCompany.Domain.UseCases.UpdateFullProductUseCase;
using InsuranceCompany.Web.Models;
using InsuranceCompany.Web.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("product")]
public class ProductController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() // url: GET /product/
    {
        return View(new GetProductsDto()
        {
            Products = (await mediator.Send(new GetProductsQuery()))
                .Select(mapper.Map<GetProductDto>)
                .ToList()
        });
    }

    [HttpGet]
    [Route("create")]
    public async Task<IActionResult> Create() // url: GET /product/create
    {
        return View(new CreateProductDto()
        {
            LobsDto = (await mediator.Send(new CreateProductQuery()))
                .Select(mapper.Map<LOBDto>)
                .ToList()
        });
    }

    [HttpPost]
    [Route("copy/{productId}")]
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
            return Ok(e);
        }
    }

    [HttpGet]
    [Route("edit/{productId}")]
    public async Task<IActionResult> Edit(int productId) // url: GET /product/edit/{id}
    {
        var editProduct = mapper.Map<EditProductDto>(await mediator.Send(new EditProductQuery(productId)));
        logger.LogInformation(JsonSerializer.Serialize(editProduct));
        return View(editProduct);
    }
    //
    [HttpPut]
    [Route("update/{productId}")]
    public async Task<IActionResult> Update(int productId, [FromBody] UpdateFullProductDto updateFullProductDto) // url: POST /product/update/{id}
    {
        var command = mapper.Map<UpdateFullProductCommand>(updateFullProductDto);
        command.ProductId = productId;
        await mediator.Send(command);
        return Ok("success");
    }
}