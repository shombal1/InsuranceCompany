using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateContractUseCase;
using InsuranceCompany.Domain.UseCases.GetContractUseCase;
using InsuranceCompany.Web.Models.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("order")]
public class ContractController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index() // url: GET /buy-product/
    {
        return View();
    }

    [HttpGet]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        logger.LogInformation("Sending request for contract getting started.");

        var contract = await mediator.Send(new GetContractQuery(id));

        if (contract == null)
        {
            return NotFound();
        }

        var contractDto = mapper.Map<GetContractDto>(contract);

        return View(contractDto);
    }

    [HttpPut]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Create([FromBody] CreateContractDto contract)
    {
        logger.LogInformation("Sending request for contract creation started.");

        var id = await mediator.Send(mapper.Map<CreateContractCommand>(contract));

        return View(id);
    }
}