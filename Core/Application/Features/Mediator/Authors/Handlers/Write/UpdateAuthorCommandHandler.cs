using Application.Constants;
using Application.Features.Mediator.Authors.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Authors.Handlers.Write
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.AuthorId);
            if(value!=null)
            {
                value.Name = request.Name;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Author>.EntityNotFound);
            }
        }
    }
}
