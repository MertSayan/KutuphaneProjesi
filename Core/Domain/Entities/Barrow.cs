using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Barrow : Entity
    {
        public int BarrowId { get; set; }
        public DateTime BarrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }=false;
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
