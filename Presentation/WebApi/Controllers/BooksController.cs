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
        [HttpGet("GetBookWithBarrowCount")]
        public async Task<IActionResult> GetBookWithBarrowCount()
        {
            var values = await _mediator.Send(new GetBookWithBarrowCountQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBookSameCategorName")]
        public async Task<IActionResult> GetAllBookSameCategorName(string categoryName)
        {
            var values = await _mediator.Send(new GetAllBookWithSameCategoryNameQuery(categoryName));
            return Ok(values);
        }

        [HttpGet("GetAllBookSameAuthorName")]
        public async Task<IActionResult> GetAllBookSameAuthorName(string authorName)
        {
            var values = await _mediator.Send(new GetAllBookWithSameAuthorNameQuery(authorName));
            return Ok(values);
        }

        [HttpGet("GetAllBookSamePublisherName")]
        public async Task<IActionResult> GetAllBookSamePublisherName(string publisherName)
        {
            var values = await _mediator.Send(new GetAllBookWithSamePublisherNameQuery(publisherName));
            return Ok(values);
        }

        [HttpGet("GetAllCategoryAuthorPublisher")]
        public async Task<IActionResult> GetAllCategoryAuthorPublisher()
        {
            var values = await _mediator.Send(new GetAllBooksWithCatAutPubQuery());
            return Ok(values);
        }

        [HttpGet("GetAllBooksForBarrow")]
        public async Task<IActionResult> GetAllBooksForBarrow()
        {
            var values = await _mediator.Send(new GetAllBooksForBarrowQuery());
            return Ok(values);
        }

    }
}
