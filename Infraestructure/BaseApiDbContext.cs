using BaseApi.WebApi.Features.Users.Entities;
using BaseApi.WebApi.Features.Common.Entities;
using Microsoft.EntityFrameworkCore;
using BaseApi.WebApi.Features.Documents.Entities;
using BaseApi.WebApi.Features.Orders.Entities;

namespace BaseApi.WebApi.Infraestructure
{
    public class BaseApiDbContext : DbContext
    {
        public BaseApiDbContext(DbContextOptions<BaseApiDbContext> options) : base(options)
        {
        }
        //Aqui agregamos las tablas que tenemos en la base de datos 
        public DbSet<User> User { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<TypePermission> TypePermission { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aqui la inicializamos las tablas que declaramos 
            new User.Map(modelBuilder.Entity<User>());
            new Permission.Map(modelBuilder.Entity<Permission>());
            new RolePermission.Map(modelBuilder.Entity<RolePermission>());
            new Role.Map(modelBuilder.Entity<Role>());
            new Theme.Map(modelBuilder.Entity<Theme>());
            new TypePermission.Map(modelBuilder.Entity<TypePermission>());       
            new Document.Map(modelBuilder.Entity<Document>());       
            new Order.Map(modelBuilder.Entity<Order>());       
            new OrderDetail.Map(modelBuilder.Entity<OrderDetail>());       
           
            base.OnModelCreating(modelBuilder);
        }
    }
}

