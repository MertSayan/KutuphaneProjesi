using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Feature:Entity
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }

    }
}
