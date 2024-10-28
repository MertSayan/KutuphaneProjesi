using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Commands
{
    public class UpdateBarrowCommand:IRequest
    {
        public int BarrowId { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsReturned { get; set; } 
    }
}
