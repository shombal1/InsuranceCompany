using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateProduct;
using InsuranceCompany.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class ProductController(IMediator mediator, IMapper mapper,ILogger<HomeController> logger) : Controller
{

    public IActionResult Index() // url: GET /product/
    {
        // логика получения всех продуктов и передача данных в View

        return View(new GetProductsDto());
    }

    public IActionResult Create() // url: GET /product/create
    {
        return View();
    }

    public IActionResult Save([FromBody] SaveProductDto saveProductDto ) // url: POST /product/save
    {
        // логика на основани data. Создание модели Product и всех связий

        return Ok("success");
    }

    public IActionResult Edit(int id) // url: GET /product/edit/{id}
    {
        // логика получения конкретного продукта и всех его связей

        return View();
    }

    public IActionResult Update(int id, [FromBody] UpdateProductDto updateProductDto) // url: POST /product/update/{id}
    {
        // логика получения конкретного продукта и его одновления
        return json(сам json);
    }
}