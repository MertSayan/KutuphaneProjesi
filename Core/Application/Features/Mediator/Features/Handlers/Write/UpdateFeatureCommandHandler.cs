using Application.Constants;
using Application.Features.Mediator.Features.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Features.Handlers.Write
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.FeatureId);
            if(value!=null)
            {
                value = _mapper.Map(request,value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Feature>.EntityNotFound);  
            }
        }
    }
}
