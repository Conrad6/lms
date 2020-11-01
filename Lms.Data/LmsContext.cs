using System;
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

        public virtual DbSet<BookBorrows> BookBorrows { get; set; }
        public virtual DbSet<BookDetails> BookDetails { get; set; }
        public virtual DbSet<BookTags> BookTags { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BorrowCheckoutItems> BorrowCheckoutItems { get; set; }
        public virtual DbSet<BorrowCheckouts> BorrowCheckouts { get; set; }
        public virtual DbSet<CustomerSubscriptions> CustomerSubscriptions { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<PermissionPolicies> PermissionPolicies { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<SubscriptionPermissions> SubscriptionPermissions { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Users> Users { get; set; }

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
            modelBuilder.Entity<BookBorrows>(entity =>
            {
                entity.HasKey(e => e.BorrowId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RequestIssuer)
                    .HasName("book_borrows_users_fk_idx");

                entity.Property(e => e.BorrowId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.RequestIssuer)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.RequestIssuerNavigation)
                    .WithMany(p => p.BookBorrows)
                    .HasForeignKey(d => d.RequestIssuer)
                    .HasConstraintName("book_borrows_users_fk");
            });

            modelBuilder.Entity<BookDetails>(entity =>
            {
                entity.HasIndex(e => e.Book)
                    .HasName("book_details_books_fk_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("'uuid()'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Book)
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

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_details_books_fk");
            });

            modelBuilder.Entity<BookTags>(entity =>
            {
                entity.HasIndex(e => e.Book)
                    .HasName("book_tags_books_fk_idx1");

                entity.HasIndex(e => e.Tag)
                    .HasName("book_tags_books_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Book)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Tag)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.BookNavigation)
                    .WithMany(p => p.BookTags)
                    .HasForeignKey(d => d.Book)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_tags_books_fk");

                entity.HasOne(d => d.TagNavigation)
                    .WithMany(p => p.BookTags)
                    .HasForeignKey(d => d.Tag)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_tags_tags_fk");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasIndex(e => e.AdderId)
                    .HasName("books_users_fk_adder_idx");

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

                entity.Property(e => e.Available).HasDefaultValueSql("b'1'");

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
                    .HasConstraintName("books_users_fk_adder");
            });

            modelBuilder.Entity<BorrowCheckoutItems>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("borrow_checkout_items_books_fk_idx");

                entity.HasIndex(e => e.CheckoutId)
                    .HasName("borrow_checkout_items_borrow_checkouts_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BookId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckoutId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowCheckoutItems)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("borrow_checkout_items_books_fk");

                entity.HasOne(d => d.Checkout)
                    .WithMany(p => p.BorrowCheckoutItems)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("borrow_checkout_items_borrow_checkouts_fk");
            });

            modelBuilder.Entity<BorrowCheckouts>(entity =>
            {
                entity.HasIndex(e => e.BorrowId)
                    .HasName("book_borrows_borrow_checkouts_fk_idx");

                entity.HasIndex(e => e.CheckoutIssuer)
                    .HasName("book_checkout_issuer_users_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BorrowId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckoutIssuer)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckoutRequestDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Borrow)
                    .WithMany(p => p.BorrowCheckouts)
                    .HasForeignKey(d => d.BorrowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_borrows_borrow_checkouts_fk");

                entity.HasOne(d => d.CheckoutIssuerNavigation)
                    .WithMany(p => p.BorrowCheckouts)
                    .HasForeignKey(d => d.CheckoutIssuer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_checkout_issuer_users_fk");
            });

            modelBuilder.Entity<CustomerSubscriptions>(entity =>
            {
                entity.HasIndex(e => e.Customer)
                    .HasName("customer_subscriptions_customers_fk_idx");

                entity.HasIndex(e => e.Subscription)
                    .HasName("customer_subscriptions_subscription_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Customer)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateRequested).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.HasBeenNotifiedForExpiration).HasDefaultValueSql("b'0'");

                entity.Property(e => e.ShouldNotifyForExpiration).HasDefaultValueSql("b'1'");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Subscription)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.Customer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_subscriptions_customers_fk");

                entity.HasOne(d => d.SubscriptionNavigation)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.Subscription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_subscriptions_subscription_fk");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NatId)
                    .HasName("nat_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
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

                entity.Property(e => e.Subscription)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PermissionPolicies>(entity =>
            {
                entity.HasIndex(e => e.Permission)
                    .HasName("permission_policies_permissions_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AccountLimit).HasDefaultValueSql("'1'");

                entity.Property(e => e.BorrowLimit).HasDefaultValueSql("'0'");

                entity.Property(e => e.CheckoutLimit).HasDefaultValueSql("'1'");

                entity.Property(e => e.Permission)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.PermissionNavigation)
                    .WithMany(p => p.PermissionPolicies)
                    .HasForeignKey(d => d.Permission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("permission_policies_permissions_fk");
            });

            modelBuilder.Entity<Permissions>(entity =>
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

            modelBuilder.Entity<SubscriptionPermissions>(entity =>
            {
                entity.HasIndex(e => e.Permission)
                    .HasName("subscription_permisions_permissions_fk_idx");

                entity.HasIndex(e => e.Subscription)
                    .HasName("subscription_permissions_subscription_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Permission)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Subscription)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.PermissionNavigation)
                    .WithMany(p => p.SubscriptionPermissions)
                    .HasForeignKey(d => d.Permission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscription_permisions_permissions_fk");

                entity.HasOne(d => d.SubscriptionNavigation)
                    .WithMany(p => p.SubscriptionPermissions)
                    .HasForeignKey(d => d.Subscription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscription_permissions_subscription_fk");
            });

            modelBuilder.Entity<Subscriptions>(entity =>
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

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Users>(entity =>
            {
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

                entity.Property(e => e.Username)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
