using Application.Features.Mediator.Barrows.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Handlers.Write
{
    public class CreateBarrowCommandHandler : IRequestHandler<CreateBarrowCommand>
    {
        private readonly IRepository<Barrow> _repository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public CreateBarrowCommandHandler(IRepository<Barrow> repository, IRepository<Book> bookRepository, IMapper mapper)
        {
            _repository = repository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBarrowCommand request, CancellationToken cancellationToken)
        {
            var value = await _bookRepository.GetByIdAsync(request.BookId);
            if (value != null && value.AvailableCopies > 0)
            {
                Barrow barrow = _mapper.Map<Barrow>(request);
                await _repository.CreateAsync(barrow);

                value.AvailableCopies--;
                await _bookRepository.UpdateAsync(value);
            }
            else
            {
                throw new Exception("Veri bulunamadı veya Müsait kitap yok");
            }

            //var value = await _bookRepository.GetByIdAsync(request.BookId);
            //if (value != null && value.AvailableCopies>0)
            //{

            //    await _repository.CreateAsync(new Barrow
            //    {
            //        BarrowDate = request.BarrowDate,
            //        BookId = request.BookId,
            //        ReturnDate = request.ReturnDate,
            //        UserId = request.UserId,
            //    });

            //    value.AvailableCopies--;
            //    await _bookRepository.UpdateAsync(value);
            //}
            //else
            //{
            //    throw new Exception("Veri bulunamadı veya Müsait kitap yok");
            //}
        }
    }
}
