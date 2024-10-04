using AutoMapper;
using InsuranceCompany.Domain.UseCases.CreateFaceUseCase;
using InsuranceCompany.Domain.UseCases.GetFaceUseCase;
using InsuranceCompany.Web.Models.Face;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Web.Controllers;

[Controller]
[Route("[controller]")]
public class FaceController(IMediator mediator, IMapper mapper, ILogger<HomeController> logger) : Controller
{
    [HttpPut]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Create([FromBody] CreateFaceDto face)
    {
        logger.LogInformation("Sending request for face creation started.");

        var id = await mediator.Send(mapper.Map<CreateFaceCommand>(face));

        return Json(new { FaceId = id });
    }

    [HttpGet]
    [Route("/[controller]/[action]")]
    public async Task<IActionResult> Get([FromQuery] int id)
    {
        logger.LogInformation("Sending request for face getting started.");

        var face = await mediator.Send(new GetFaceQuery(id));

        if (face == null)
        {
            return NotFound();
        }

        var faceDto = mapper.Map<GetFaceDto>(face);

        return View(faceDto);
    }
}