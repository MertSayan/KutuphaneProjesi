using Application.Constants;
using Application.Features.Mediator.Categories.Commands;
using Application.Features.Mediator.Categories.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var values = await _mediator.Send(new GetCategoryQuery());
            return Ok(values);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Category>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Category>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok(Messages<Category>.EntityDeleted);
        }
    }
}
