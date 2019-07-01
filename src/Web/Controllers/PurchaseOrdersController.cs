using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrdersController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }


        public ActionResult<List<PurchaseOrderModel>> GetAll()
        {
            return _purchaseOrderService.GetAllPurchaseOrders()
                .Select(po => new PurchaseOrderModel() { ProductId = po.ProductId, Quantity = po.Quantity }).ToList();
        }
    }
}