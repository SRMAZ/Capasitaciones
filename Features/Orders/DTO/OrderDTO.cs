using BaseApi.WebApi.Features.Orders.Entities;

namespace BaseApi.WebApi.Features.Orders.DTO
{
    public class OrderDTO : Order
    {
        public string CreateByName { get; set; }

    }
}
