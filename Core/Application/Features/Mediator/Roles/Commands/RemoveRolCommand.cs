using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Roles.Commands
{
    public class RemoveRolCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveRolCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
