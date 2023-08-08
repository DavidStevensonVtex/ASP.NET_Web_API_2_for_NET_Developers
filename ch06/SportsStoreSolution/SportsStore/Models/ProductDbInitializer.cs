using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace SportsStore.Models
{
    //public class ProductDbInitializer : DropCreateDatabaseAlways<ProductDbContext>
    public class ProductDbInitializer : CreateDatabaseIfNotExists<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new List<Product>
                {
                    new Product { Name = "Kayak", Description = "A boat for one person", Category = "Watersports", Price = 275 },
                    new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersports", Price = 48.95m },
                    new Product { Name = "Soccer ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50m },
                    new Product { Name = "Corner flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 34.95m },
                    new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 79500 },
                    new Product { Name = "Thinking Cap", Description = "Improve brain efficiency by 75%", Category = "Chess", Price = 16 },
                    new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Category = "Chess", Price = 29.95m },
                    new Product { Name = "Human Chess Board", Description = "A fun game for the family", Category = "Chess", Price = 75 },
                    new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamond studded King", Category = "Chess", Price = 1200 }
                });

                context.SaveChanges();

                context.Orders.AddRange(
                    new List<Order>()
                    {
						new Order() { Customer = "Alice Smith", TotalCost = 68.45m, Lines = 
                            new List<OrderLine>
                            {
                                new OrderLine() { ProductId = 2, Count = 2 },
                                new OrderLine() { ProductId = 3, Count = 1 }
                            } 
                        },
						new Order() { Customer = "Peter Jones", TotalCost = 79791m, Lines = 
                            new List<OrderLine>
                            {
                                new OrderLine() { ProductId = 5, Count = 1 },
                                new OrderLine() { ProductId = 6, Count = 3 },
                                new OrderLine() { ProductId = 1, Count = 3 }
                            } 
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}