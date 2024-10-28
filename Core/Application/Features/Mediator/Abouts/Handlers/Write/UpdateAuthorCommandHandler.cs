using Application.Constants;
using Application.Features.Mediator.Abouts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Abouts.Handlers.Write
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {

            var value=await _repository.GetByIdAsync(request.AboutId);
            if (value != null)
            {
                value=_mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<About>.EntityNotFound);
            }
        }
    }
}
