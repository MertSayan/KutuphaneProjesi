using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Banners.Commands
{
    public class UpdateBannerCommand:IRequest
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
