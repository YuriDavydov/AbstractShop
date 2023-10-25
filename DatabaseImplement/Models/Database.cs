using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DatabaseImplement.Models;

public class Database : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=database1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=database1;Integrated Security=True;");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Component>().HasData(new Component
        {
            Id = 1,
            ComponentName = "рыба1"
        }, new Component
        {
            Id = 2,
            ComponentName = "масло"
        });
        modelBuilder.Entity<ProductComponent>().HasData(new ProductComponent
        {
            Id = 3,
            ProductId = 1,
            ComponentId = 1,
            Count = 1
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            ProductName = "тест",
            Price = 1000
        }
            );
        /*  modelBuilder.Entity<Order>().HasData(new Order
         {
             /*
             Id = 1,
             ProductId = 1,
             ImplementerId = null,
             Count = 10,
             Sum = 10000,
             Status = BusinessLogic.Enums.OrderStatus.Finish,
             DateCreate = new DateTime(2023, 7, 1, 12, 44, 50),
             DateImplement = new DateTime(2023, 7, 6, 18, 14, 22)
             
 }); */

}

public DbSet<Component> Components { set; get; }
public DbSet<Product> Products { set; get; }
public DbSet<ProductComponent> ProductComponents { set; get; }
public DbSet<Order> Orders { set; get; }
public DbSet<User> Users { set; get; }
public DbSet<Implementer> Implementers {set; get; }
public DbSet<MessageInfoDatabase> MessageInfo { set; get; }
}
