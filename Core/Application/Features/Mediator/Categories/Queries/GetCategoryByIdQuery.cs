using Application.Features.Mediator.Categories.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Queries
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
