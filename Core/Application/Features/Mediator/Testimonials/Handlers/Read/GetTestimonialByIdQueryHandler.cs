using Application.Features.Mediator.Testimonials.Queries;
using Application.Features.Mediator.Testimonials.Results;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Handlers.Read
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if(value != null)
            {
                var result=_mapper.Map<GetTestimonialByIdQueryResult>(value);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
