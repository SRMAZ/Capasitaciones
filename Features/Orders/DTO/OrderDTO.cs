using OrderPurches.WebApi.Features.Orders.Entities;

namespace OrderPurches.WebApi.Features.Orders.DTO
{
    public class OrderDTO : Order
    {
        public string CreatedByName { get; set; }

    }
}
