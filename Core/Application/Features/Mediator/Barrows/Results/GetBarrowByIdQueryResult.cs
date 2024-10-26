using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Barrows.Results
{
    public class GetBarrowByIdQueryResult
    {
        public int BarrowId { get; set; }
        public DateTime BarrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
