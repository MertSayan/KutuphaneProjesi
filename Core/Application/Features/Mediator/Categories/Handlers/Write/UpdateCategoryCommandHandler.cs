using Application.Constants;
using Application.Features.Mediator.Categories.Commands;
using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.CategoryId);
            if (value != null)
            {
                value=_mapper.Map(request,value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Category>.EntityNotFound);
            }
        }
    }
}
