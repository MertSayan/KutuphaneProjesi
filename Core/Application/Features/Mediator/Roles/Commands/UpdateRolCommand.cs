using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Commands
{
    public class UpdateRolCommand:IRequest
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
