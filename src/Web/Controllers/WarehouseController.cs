using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace NOMSS.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IOrderFulfilmentService _orderFulfilmentService;

        public WarehouseController(IOrderFulfilmentService orderFulfilmentService)
        {
            _orderFulfilmentService = orderFulfilmentService;
        }

        // GET api/values
        [HttpPost("fulfilment")]
        public ActionResult<OrderFulfilmentResultModel> Fulfilment([FromBody] OrderFulfilmentRequest request)
        {

            var unfulfilledOrders = _orderFulfilmentService.FulfilOrders(request.OrderIds);

            var model = new OrderFulfilmentResultModel() {
                Unfulfillable = unfulfilledOrders.ToList()
            };
            return model;
        }


    }
}
