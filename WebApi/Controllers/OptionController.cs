using Application.Survey.Commands;
using Application.Survey.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Request.Update;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{surveyId}")]
        public async Task<IActionResult> Get([FromRoute] int surveyId)
        {
            var query = new GetSurveyByIdQuery(surveyId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{surveyId}")]
        public async Task<IActionResult> Update([FromRoute] int surveyId, [FromBody] SurveyUpdateRequest request, CancellationToken token)
        {
            var options = request.Options.Select(x => new Option
            {
                Description = x.Description,
                Type = x.Type,
                Order = x.Order
            }).ToList();
            var command = new SurveyUpdateCommand(surveyId, request.Question, request.CreatedBy, options, request.Settings);
            await _mediator.Send(command, token);
            return Ok();
        }




    }
}
