using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Books.Commands
{
    public class RemoveBookCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBookCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
