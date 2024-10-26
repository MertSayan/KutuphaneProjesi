using Application.Features.Mediator.Roles.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Queries
{
    public class GetRolQuery:IRequest<List<GetRolQueryResult>>
    {
    }
}
