using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Commands
{
    public class CreateBarrowCommand:IRequest
    {
        public DateTime BarrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
