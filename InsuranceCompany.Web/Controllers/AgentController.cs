using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateAgentUseCase;
using InsuranceCompany.Domain.UseCases.GetAgentUseCase;
using InsuranceCompany.Web.Models.Agent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class AgentController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpPut]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Create([FromBody] CreateAgentDto agent)
    {
        logger.LogInformation("Sending request for face creation started.");

        var id = await mediator.Send(mapper.Map<CreateAgentCommand>(agent));

        return Json(new { FaceId = id });
    }

    [HttpGet]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        logger.LogInformation("Sending request for face getting started.");

        var face = await mediator.Send(new GetAgentQuery(id));

        if (face == null)
        {
            return NotFound();
        }

        var faceDto = mapper.Map<GetAgentDto>(face);

        return View(faceDto);
    }
}