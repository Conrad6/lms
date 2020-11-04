using System;
using Lms.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lms.Data
{
    public partial class LmsContext : DbContext
    {
        public LmsContext()
        {
        }

        public LmsContext(DbContextOptions<LmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetails> BookDetails { get; set; }
        public virtual DbSet<BookTag> BookTags { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowCheckoutItem> BorrowCheckoutItems { get; set; }
        public virtual DbSet<BorrowCheckout> BorrowCheckouts { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
        public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PermissionPolicy> PermissionPolicies { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<StockDelivery> StockDeliveries { get; set; }
        public virtual DbSet<StockDeliveryItem> StockDeliveryItems { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SubscriptionPermission> SubscriptionPermissions { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=library_db;sslmode=None;uid=root", x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetails>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("'uuid()'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Edition)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Publisher)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Website)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<BookTag>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("fk_book_tags_books1_idx");

                entity.HasIndex(e => e.TagId)
                    .HasName("fk_book_tags_tags1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BookId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TagId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookTags)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_book_tags_books1");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BookTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_book_tags_tags1");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.AdderId)
                    .HasName("fk_books_users1_idx");

                entity.HasIndex(e => e.BookDetailsId)
                    .HasName("fk_books_book_details1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("book_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdderId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Author)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Available).HasDefaultValueSql("'1'");

                entity.Property(e => e.BookDetailsId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CopiesAvailable).HasDefaultValueSql("'1'");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Description)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Genre)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Isbn)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TotalCopies).HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Adder)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AdderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_books_users1");

                entity.HasOne(d => d.BookDetails)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.BookDetailsId)
                    .HasConstraintName("fk_books_book_details1");
            });

            modelBuilder.Entity<BorrowCheckoutItem>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("fk_borrow_checkout_items_books1_idx");

                entity.HasIndex(e => e.BorrowCheckoutId)
                    .HasName("fk_borrow_checkout_items_borrow_checkouts1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BookId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BorrowCheckoutId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowCheckoutItems)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrow_checkout_items_books1");

                entity.HasOne(d => d.BorrowCheckout)
                    .WithMany(p => p.BorrowCheckoutItems)
                    .HasForeignKey(d => d.BorrowCheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrow_checkout_items_borrow_checkouts1");
            });

            modelBuilder.Entity<BorrowCheckout>(entity =>
            {
                entity.HasIndex(e => e.BorrowId)
                    .HasName("fk_borrow_checkouts_borrows1_idx");

                entity.HasIndex(e => e.IssuerId)
                    .HasName("fk_borrow_checkouts_users1_idx");

                entity.HasIndex(e => e.StockId)
                    .HasName("fk_borrow_checkouts_stocks1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BorrowId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckoutRequestDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.IssuerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StockId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Borrow)
                    .WithMany(p => p.BorrowCheckouts)
                    .HasForeignKey(d => d.BorrowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrow_checkouts_borrows1");

                entity.HasOne(d => d.Issuer)
                    .WithMany(p => p.BorrowCheckouts)
                    .HasForeignKey(d => d.IssuerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrow_checkouts_users1");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.BorrowCheckouts)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrow_checkouts_stocks1");
            });

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("fk_borrows_customers1_idx");

                entity.HasIndex(e => e.IssuerId)
                    .HasName("fk_borrows_users1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IssuerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrows_customers1");

                entity.HasOne(d => d.Issuer)
                    .WithMany(p => p.Borrows)
                    .HasForeignKey(d => d.IssuerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_borrows_users1");
            });

            modelBuilder.Entity<CustomerSubscription>(entity =>
            {
                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("fk_customer_subscriptions_subscriptions1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateRequested).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.HasBeenNotifiedForExpiration).HasDefaultValueSql("'0'");

                entity.Property(e => e.ShouldNotifyForExpiration).HasDefaultValueSql("'1'");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubscriptionId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_subscriptions_subscriptions1");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.AdderId)
                    .HasName("fk_customers_users1_idx");

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NatId)
                    .HasName("nat_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("fk_customers_customer_subscriptions1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdderId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateAdded).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Names)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NatId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubscriptionId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Adder)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AdderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customers_users1");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customers_customer_subscriptions1");
            });

            modelBuilder.Entity<PermissionPolicy>(entity =>
            {
                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk_permission_policies_permissions1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AccountLimit).HasDefaultValueSql("'1'");

                entity.Property(e => e.BorrowLimit).HasDefaultValueSql("'0'");

                entity.Property(e => e.CheckoutLimit).HasDefaultValueSql("'1'");

                entity.Property(e => e.PermissionId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionPolicies)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_permission_policies_permissions1");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("normalized_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("'uuid()'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DisplayName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NormalizedName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<StockDelivery>(entity =>
            {
                entity.HasIndex(e => e.RecepientId)
                    .HasName("fk_stock_deliveries_users1_idx");

                entity.HasIndex(e => e.StockId)
                    .HasName("fk_stock_deliveries_stocks1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeliveryDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.RecepientId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StockId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Recepient)
                    .WithMany(p => p.StockDeliveries)
                    .HasForeignKey(d => d.RecepientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stock_deliveries_users1");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockDeliveries)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stock_deliveries_stocks1");
            });

            modelBuilder.Entity<StockDeliveryItem>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("fk_stock_delivery_items_books1_idx");

                entity.HasIndex(e => e.StockDeliveryId)
                    .HasName("fk_stock_delivery_items_stock_deliveries1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BookId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StockDeliveryId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.StockDeliveryItems)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stock_delivery_items_books1");

                entity.HasOne(d => d.StockDelivery)
                    .WithMany(p => p.StockDeliveryItems)
                    .HasForeignKey(d => d.StockDeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stock_delivery_items_stock_deliveries1");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasIndex(e => e.OwnerId)
                    .HasName("fk_stocks_users1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.OwnerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_stocks_users1");
            });

            modelBuilder.Entity<SubscriptionPermission>(entity =>
            {
                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk_subscription_permissions_permissions1_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("fk_subscription_permissions_subscriptions1_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PermissionId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubscriptionId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.SubscriptionPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subscription_permissions_permissions1");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionPermissions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subscription_permissions_subscriptions1");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("normalized_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DisplayName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NormalizedName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.BossId)
                    .HasName("fk_users_users1_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Avatar)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BossId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Email)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Gender)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserRole)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.InverseBoss)
                    .HasForeignKey(d => d.BossId)
                    .HasConstraintName("fk_users_users1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
