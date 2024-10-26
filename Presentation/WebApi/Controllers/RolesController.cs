using Application.Constants;
using Application.Features.Mediator.Roles.Commands;
using Application.Features.Mediator.Roles.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleList()
        {
            var values = await _mediator.Send(new GetRolQuery());
            return Ok(values);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var values = await _mediator.Send(new GetRolByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRolCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Role>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRolCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Role>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveRole(int id)
        {
            await _mediator.Send(new RemoveRolCommand(id));
            return Ok(Messages<Role>.EntityDeleted);
        }
    }
}
