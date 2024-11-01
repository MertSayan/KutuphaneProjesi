﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Publisher : Entity
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }   = new List<Book>();
    }
}
