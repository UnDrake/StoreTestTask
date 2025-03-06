using StoreTestTask.Data.Models;


namespace StoreTestTask.Data
{
    public static class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(new List<Client>
                {
                    new Client 
                    { 
                        FullName = "Alexander Ivanenko", 
                        BirthDate = new DateTime(2003, 3, 5), 
                        RegistrationDate = new DateTime(2023, 2, 10)
                    },
                    new Client 
                    { 
                        FullName = "Marina Petrenko", 
                        BirthDate = new DateTime(2000, 7, 12), 
                        RegistrationDate = new DateTime(2023, 6, 15) 
                    },
                    new Client 
                    { 
                        FullName = "Ivan Gordienko", 
                        BirthDate = new DateTime(1985, 12, 1), 
                        RegistrationDate = new DateTime(2022, 12, 25) 
                    }
                });

                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product 
                    { 
                        Name = "Laptop ASUS ROG", 
                        Category = "Electronics", 
                        Article = Guid.NewGuid().ToString().Substring(0, 8), 
                        Price = 2000 
                    },
                    new Product 
                    { 
                        Name = "Smartphone Samsung Galaxy", 
                        Category = "Electronics", 
                        Article = Guid.NewGuid().ToString().Substring(0, 8),
                        Price = 1200 
                    },
                    new Product 
                    { 
                        Name = "Coffee Machine DeLonghi", 
                        Category = "Kitchen Appliances", 
                        Article = Guid.NewGuid().ToString().Substring(0, 8), 
                        Price = 500 
                    },
                    new Product 
                    { 
                        Name = "Refrigerator LG", 
                        Category = "Home Appliances", 
                        Article = Guid.NewGuid().ToString().Substring(0, 8), 
                        Price = 1500 
                    }
                });

                context.SaveChanges();
            }

            if (!context.Purchases.Any())
            {
                var purchases = new List<Purchase>
                {
                    new Purchase
                    {
                        ClientId = 1,
                        Date = DateTime.UtcNow.AddDays(-2),
                        OrderNumber = Guid.NewGuid().ToString().Substring(0, 8)
                    },
                    new Purchase
                    {
                        ClientId = 2,
                        Date = DateTime.UtcNow.AddDays(-5),
                        OrderNumber = Guid.NewGuid().ToString().Substring(0, 8)
                    },
                    new Purchase
                    {
                        ClientId = 3,
                        Date = DateTime.UtcNow.AddDays(-1),
                        OrderNumber = Guid.NewGuid().ToString().Substring(0, 8)
                    }
                };

                context.Purchases.AddRange(purchases);
                context.SaveChanges();

                if (!context.PurchaseDetails.Any())
                {
                    var purchaseDetails = new List<PurchaseDetail>
                    {
                        new PurchaseDetail 
                        { 
                            PurchaseId = purchases[0].Id, 
                            ProductId = 1, 
                            Quantity = 3
                        },
                        new PurchaseDetail 
                        { 
                            PurchaseId = purchases[0].Id, 
                            ProductId = 2, 
                            Quantity = 2
                        },
                        new PurchaseDetail 
                        { 
                            PurchaseId = purchases[1].Id, 
                            ProductId = 3, 
                            Quantity = 4
                        },
                        new PurchaseDetail 
                        { 
                            PurchaseId = purchases[2].Id, 
                            ProductId = 4, 
                            Quantity = 1 
                        }
                    };

                    context.PurchaseDetails.AddRange(purchaseDetails);
                    context.SaveChanges();
                }
            }
        }
    }
}