using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class OrderFulfilmentRequest
    {
        public List<int> OrderIds { get; set; }
    }
}
