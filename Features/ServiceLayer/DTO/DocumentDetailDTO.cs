using System;

namespace OrderPurches.WebApi.Features.ServiceLayer.DTO
{
    public class DocumentDetailDTO
    {
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string TaxCode
        {
            get; set;


        }

    }
}
