using OrderPurches.WebApi.Features.Documents.Services;
using OrderPurches.WebApi.Features.Orders.Entities;
using OrderPurches.WebApi.Features.Orders.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OrderPurches.WebApi.Features.Orders
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _OrderServices;

        public OrderController(OrderServices orderServices)
        {
            _OrderServices = orderServices;
        }

        [HttpGet("GetOrder")]
        public ActionResult GetDocument()
        {
            try
            {
                var Document = _OrderServices.GetOrder();
                return Ok(Document);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public ActionResult Add(Order entity)
        {
            try
            {
                var Document = _OrderServices.AddOrder(entity);
                return Ok(Document);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOrderByDate/{fro}/{to}")]
        public ActionResult GetOrderByDate(DateTime fro, DateTime to)
        {
            try
            {
                var Document = _OrderServices.GetOrderByDate(fro,to);
                return Ok(Document);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
