using Application.Constants;
using Application.Features.Mediator.Banners.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Banners.Handlers.Write
{
    public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            if (value != null || value.DeletedDate!=null)
            {
                await _repository.RemoveAsync(value);
            }
            else
            {
                throw new Exception(Messages<Banner>.EntityDeleted+ "ya da" + Messages<Banner>.EntityNotFound);
            }
        }
    }
}
