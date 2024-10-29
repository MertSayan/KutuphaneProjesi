using Application.Features.Mediator.Books.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Queries
{
    public class GetAllBookWithSameAuthorNameQuery:IRequest<List<GetAllBookWithSameThingQueryResult>>
    {
        public string AuthorName { get; set; }

        public GetAllBookWithSameAuthorNameQuery(string authorName)
        {
            AuthorName = authorName;
        }
    }
}
