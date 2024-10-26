using Application.Features.Mediator.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Users.Queries
{
    public class GetUserByIdQuery:IRequest<GetUserByIdQueryResult>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
