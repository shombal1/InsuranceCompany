using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateContractUseCase;
using InsuranceCompany.Web.Models.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class ContractController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpPut]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Create([FromBody] ContractDto contract)
    {
        logger.LogInformation("Sending request for contract creation started.");

        var id = await mediator.Send(mapper.Map<CreateContractCommand>(contract));

        return View(id);
    }
}