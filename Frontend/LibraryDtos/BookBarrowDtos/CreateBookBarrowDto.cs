using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDtos.BookBarrowDtos
{
    public class CreateBookBarrowDto
    {
        public DateTime BarrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string UserMail { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

    }
}
