using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;

namespace BaseApi.WebApi.Features.Orders.Entities
{

    public class OrderDetail
    {
        public int IdDatail { get; set; }
        public int IdOrder { get; set; }
        public string ItemCode { get; set; }
        public string IteamName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public Order Order { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.ItemCode)) throw new System.Exception("Debe ingresar un Codigo");
            return true;
        }

        public class Map
        {
            public Map(EntityTypeBuilder<OrderDetail> builder)
            {
                builder.HasKey(x => x.IdDatail);
                builder.Property(x => x.IdOrder).HasColumnName("IdOrder");
                builder.Property(x => x.ItemCode).HasColumnName("ItemCode");
                builder.Property(x => x.Price).HasColumnName("Price");
                builder.Property(x => x.IteamName).HasColumnName("IteamName");
                builder.Property(x => x.Quantity).HasColumnName("Quantity");
                builder.HasOne(x => x.Order).WithMany(x => x.Detail).HasForeignKey(x => x.IdOrder);
                builder.ToTable("OrderDetail");
            }
        }
    }


}
