using Application.Features.Mediator.Books.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Queries
{
    public class GetAllBookWithSamePublisherNameQuery:IRequest<List<GetAllBookWithSameThingQueryResult>>
    {
        public string PublisherName { get; set; }

        public GetAllBookWithSamePublisherNameQuery(string publisherName)
        {
            PublisherName = publisherName;
        }
    }
}
