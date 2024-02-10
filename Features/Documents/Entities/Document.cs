using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BaseApi.WebApi.Features.Documents.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public int CreateBy { get; set; }
        public string Name { get; set; }
        public DateTime CreatebyDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.Name)) throw new System.Exception("Debe ingresar un nombre");
            return true;
        }

        public class Map
        {
            public Map(EntityTypeBuilder<Document> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).HasColumnName("Name");
                builder.Property(x => x.CreateBy).HasColumnName("CreateBy");
                builder.Property(x => x.CreatebyDate).HasColumnName("CreatebyDate");
                builder.Property(x => x.UpdateBy).HasColumnName("UpdateBy");
                builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");
                builder.ToTable("Document");
            }
        }
    }
}
