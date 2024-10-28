using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDtos.BookDtos
{
    public class ResultTopGiveBooks
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int? AvailableCopies { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public string BookImageUrl { get; set; }
    }
}
