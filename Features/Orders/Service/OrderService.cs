using BaseApi.WebApi.Features.Orders.DTO;
using BaseApi.WebApi.Features.Orders.Entities;
using BaseApi.WebApi.Infraestructure;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseApi.WebApi.Features.Orders.Service
{
    public class OrderServices
    {
        private readonly BaseApiDbContext _context;

        public OrderServices(BaseApiDbContext context)
        {
            _context = context;
        }

        public List<OrderDTO> GetOrders()
        {


            var result = (from order in _context.Order
                          join user in _context.User on order.CreateBy equals user.UserId
                          select new OrderDTO {
                              DocNum = order.DocNum,
                              DocEntry = order.DocEntry,
                              DocDate = order.DocDate,
                              DocCode = order.DocCode,
                              Reference = order.Reference,
                              CreateBy = order.CreateBy,
                              CreateByName = user.Name,
                              Detail = (_context.OrderDetail.Where(x => x.IdDatail == order.DocNum).ToList())
                          }).ToList();

            return result;
        }

        public List<OrderDTO> AddOrder(Order request)
        {
            request.DocTotal = request.Detail.Sum(x => x.Quantity * x.Price);
            request.DocDate = DateTime.Now;
            _context.Order.Add(request);
            _context.SaveChanges(); 
            return GetOrders();
        }

    }
}
