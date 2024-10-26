using Application.Features.Mediator.Books.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Queries
{
    public class GetBookByIdQuery:IRequest<GetBookByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
