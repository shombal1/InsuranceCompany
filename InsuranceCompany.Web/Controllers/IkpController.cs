using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateIkpUseCase;
using InsuranceCompany.Domain.UseCases.GetIkpUseCase;
using InsuranceCompany.Web.Models.Ikp;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class IkpController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpPut]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Create([FromBody] CreateIkpDto ikp)
    {
        logger.LogInformation("Sending request for IKP creation started.");

        var id = await mediator.Send(mapper.Map<CreateIkpCommand>(ikp));

        return Json(new { IkpId = id });
    }

    [HttpGet]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        logger.LogInformation("Sending request for IKP getting started.");

        var face = await mediator.Send(new GetIkpQuery(id));

        if (face == null)
        {
            return NotFound();
        }

        var ikpDto = mapper.Map<GetIkpDto>(face);

        return View(ikpDto);
    }
}