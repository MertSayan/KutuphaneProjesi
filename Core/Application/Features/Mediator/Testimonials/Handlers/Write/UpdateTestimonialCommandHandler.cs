using Application.Constants;
using Application.Features.Mediator.Testimonials.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Handlers.Write
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.TestimonialId);
            if (value != null)
            {
                value = _mapper.Map(request,value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Testimonial>.EntityNotFound);
            }
        }
    }
}
