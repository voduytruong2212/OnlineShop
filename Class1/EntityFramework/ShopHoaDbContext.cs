namespace Class1.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopHoaDbContext : DbContext
    {
        public ShopHoaDbContext()
            : base("name=ShopHoaDbContext")
        {
        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Oder> Oders { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(e => e.Metatitle)
                .IsUnicode(false);

            modelBuilder.Entity<Oder>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Payment)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.PaymentInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Security)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserTypeID)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID);
        }
    }
}
