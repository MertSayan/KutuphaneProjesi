﻿using Application.Constants;
using Application.Features.Mediator.Users.Commands;
using Application.Features.Mediator.Users.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var values = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<User>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveUser(int id)
        {
            await _mediator.Send(new RemoveUserCommand(id));
            return Ok(Messages<User>.EntityDeleted);
        }
    }
}
