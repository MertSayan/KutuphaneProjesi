using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Commands
{
    public class CreateCategoryCommand:IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
