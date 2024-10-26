using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Commands
{
    public class CreateRolCommand:IRequest
    {

        public string Name { get; set; }
    }
}
