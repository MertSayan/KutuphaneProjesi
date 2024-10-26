using Application.Features.Mediator.Barrows.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Queries
{
    public class GetBarrowByIdQuery:IRequest<GetBarrowByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBarrowByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
