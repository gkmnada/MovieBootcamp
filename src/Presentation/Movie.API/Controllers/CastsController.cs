using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Cast.Commands;
using Movie.Application.Features.Cast.Queries;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateCast")]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("ListCasts")]
        public async Task<IActionResult> ListCasts()
        {
            var query = new GetCastQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var query = new GetCastByIdQuery(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPut("UpdateCast")]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCast(int id)
        {
            var command = new DeleteCastCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
