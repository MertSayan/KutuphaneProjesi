using Application.Features.Mediator.Roles.Results;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Queries
{
    public class GetRolByIdQuery:IRequest<GetRolByIdQueryResult>
    {
        public int Id { get; set; }

        public GetRolByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
