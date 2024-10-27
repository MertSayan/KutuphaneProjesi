using Application.Features.Mediator.Banners.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Banners.Queries
{
    public class GetBannerQuery:IRequest<List<GetBannerQueryResult>>
    {
    }
}
