using Application.Constants;
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
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public UpdateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.BannerId);
            if (value != null)
            {
                value = _mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception(Messages<Banner>.EntityNotFound);
            }

            
            
            
            
            //if (value != null)
            //{
            //    value.Title = request.Title;
            //    value.Description = request.Description;
            //    await _repository.UpdateAsync(value);
            //}
            //else
            //{
            //    throw new Exception(Messages<Banner>.EntityNotFound);
            //}
        }
    }
}
