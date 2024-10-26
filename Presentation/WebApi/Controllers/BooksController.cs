using Application.Constants;
using Application.Features.Mediator.Books.Commands;
using Application.Features.Mediator.Books.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookList()
        {
            var values = await _mediator.Send(new GetBookQuery());
            return Ok(values);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var values = await _mediator.Send(new GetBookByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Book>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Book>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _mediator.Send(new RemoveBookCommand(id));
            return Ok(Messages<Book>.EntityDeleted);
        }
    }
}
