using Application.Vote;
using Application.Vote.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Request;
using WebApi.Models.Request.Create;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VoteCreateRequest request, CancellationToken token)
        {
            var command = request.ToCommand(request.SurveyId);
            await _mediator.Send(command, token);
            return Ok();
        }










    }
}
