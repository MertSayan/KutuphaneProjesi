using Application.Constants;
using Application.Features.Mediator.Barrows.Commands;
using Application.Features.Mediator.Barrows.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarrowsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarrowsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBarrowList()
        {
            var values = await _mediator.Send(new GetBarrowQuery());
            return Ok(values);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetBarrowById(int id)
        {
            var values = await _mediator.Send(new GetBarrowByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBarrow(CreateBarrowCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Barrow>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBarrow(UpdateBarrowCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Barrow>.EntityUpdated);
        }
        
    }
}