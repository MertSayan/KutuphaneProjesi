using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : Entity
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int? TotalCopies { get; set; } = 1;
        public int? AvailableCopies { get; set; } = 1;
        public int AuthorId { get; set; }
        public Author Author { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<Barrow> Barrows { get; set; } = new List<Barrow>();
    }
}
