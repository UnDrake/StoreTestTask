using Microsoft.EntityFrameworkCore;
using StoreTestTask.Data.Models;


namespace StoreTestTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(x => x.Article)
                    .IsUnique();

                entity.Property(x => x.Price)
                    .HasPrecision(18, 2);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasIndex(x => x.OrderNumber)
                    .IsUnique();

                entity.HasOne(x => x.Client)
                    .WithMany(x => x.Purchases)
                    .HasForeignKey(x => x.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasKey(x => new { x.ProductId, x.PurchaseId });

                entity.HasOne(x => x.Product)
                    .WithMany(x => x.PurchaseDetails)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Purchase)
                    .WithMany(x => x.PurchaseDetails)
                    .HasForeignKey(x => x.PurchaseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
