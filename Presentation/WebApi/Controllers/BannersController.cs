using Application.Constants;
using Application.Features.Mediator.Banners.Commands;
using Application.Features.Mediator.Banners.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBannerList()
        {
            var values = await _mediator.Send(new GetBannerQuery());
            return Ok(values);
        }
        //[HttpGet("GetByID")]
        //public async Task<IActionResult> GetBannerById(int id)
        //{
        //    var values = await _mediator.Send(new GetBannerByIdQuery(id));
        //    return Ok(values);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Banner>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Banner>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _mediator.Send(new RemoveBannerCommand(id));
            return Ok(Messages<Banner>.EntityDeleted);
        }
    }
}
