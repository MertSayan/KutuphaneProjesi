using Application.Features.Mediator.Categories.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Queries
{
    public class GetCategoryQuery:IRequest<List<GetCategoryQueryResult>>
    {
    }
}
