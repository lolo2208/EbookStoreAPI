using EbookStoreAPI.BE;
using Microsoft.EntityFrameworkCore;

namespace EbookStoreAPI.DBConnection
{
    public class EbookStoreDbContext : DbContext
    {
        public EbookStoreDbContext(DbContextOptions<EbookStoreDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<RoleBE> Roles { get; set; }
        public DbSet<UserBE> Users { get; set; }
        public DbSet<BookBE> Books { get; set; }
        public DbSet<ShoppingCartBE> ShoppingCarts { get; set; }
        public DbSet<SaleBE> Sales { get; set; }
        public DbSet<SaleDetailBE> SaleDetails { get; set; }
        public DbSet<ShopCartDetailBE> ShopCartDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBE>()
                .HasOne(u => u.RoleNavigation)
                .WithMany()
                .HasForeignKey(u => u.Role);

            //--------------------------------------------------------

            modelBuilder.Entity<ShoppingCartBE>()
                .HasOne(sc => sc.CustomerNavigation)
                .WithMany()
                .HasForeignKey(sc => sc.Customer);

            //--------------------------------------------------------

            modelBuilder.Entity<ShopCartDetailBE>()
                .HasOne(scd => scd.ShoppingCartNavigation)
                .WithMany()
                .HasForeignKey(scd => scd.ShoppingCart);

            modelBuilder.Entity<ShopCartDetailBE>()
                .HasOne(scd => scd.BookNavigation)
                .WithMany()
                .HasForeignKey(sd => sd.Book);

            //--------------------------------------------------------

            modelBuilder.Entity<SaleBE>()
                .HasOne(s => s.CustomerNavigation)
                .WithMany()
                .HasForeignKey(s => s.Customer);

            //--------------------------------------------------------

            modelBuilder.Entity<SaleDetailBE>()
                .HasOne(sd => sd.SaleNavigation)
                .WithMany()
                .HasForeignKey(sd => sd.Sale);

            modelBuilder.Entity<SaleDetailBE>()
                .HasOne(sd => sd.BookNavigation)
                .WithMany()
                .HasForeignKey(sd => sd.Book);
        }
    }
}
