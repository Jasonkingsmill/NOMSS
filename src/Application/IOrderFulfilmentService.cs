using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IOrderFulfilmentService
    {
        IEnumerable<int> FulfilOrders(List<int> orderIds);
    }
}
