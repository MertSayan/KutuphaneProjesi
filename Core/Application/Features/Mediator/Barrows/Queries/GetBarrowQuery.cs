using Application.Features.Mediator.Barrows.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Queries
{
    public class GetBarrowQuery:IRequest<List<GetBarrowQueryResult>>
    {
    }
}
