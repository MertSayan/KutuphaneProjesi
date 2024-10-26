using Application.Constants;
using Application.Features.Mediator.Authors.Commands;
using Application.Features.Mediator.Authors.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
            
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var values = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Author>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Author>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok(Messages<Author>.EntityDeleted);
        }
    }
}
