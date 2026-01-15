using Application.Accidents.Commands;
using Application.Accidents.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SiniestrosAPI.Controllers
{
    [ApiController]
    [Route("api/accidents")]
    public class AccidentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccidentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccidentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string? department,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetAccidentsQuery(department, from, to, page, pageSize));

            return Ok(result);
        }
    }
}
