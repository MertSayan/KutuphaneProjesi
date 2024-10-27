using Application.Features.Mediator.Banners.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Banners.Handlers.Write
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public CreateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {

            Banner banner = _mapper.Map<Banner>(request);
            await _repository.CreateAsync(banner);

            //await _repository.CreateAsync(new Banner
            //{
            //    Description = request.Description,
            //    Title = request.Title
            //});
        }
    }
}
