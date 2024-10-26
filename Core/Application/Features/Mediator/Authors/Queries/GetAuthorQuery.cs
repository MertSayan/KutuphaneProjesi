using Application.Features.Mediator.Authors.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Authors.Queries
{
    public class GetAuthorQuery:IRequest<List<GetAuthorQueryResult>>
    {
    }
}
