﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Banner:Entity
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
