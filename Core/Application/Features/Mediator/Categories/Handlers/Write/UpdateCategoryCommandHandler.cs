using Application.Constants;
using Application.Features.Mediator.Categories.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Handlers.Write
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.CategoryId);
            if (value != null)
            {
                value.Description = request.Description;
                value.Name = request.Name;
            }
            else
            {
                throw new Exception(Messages<Category>.EntityNotFound);
            }
        }
    }
}
