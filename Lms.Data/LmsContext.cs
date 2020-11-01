using Lms.Core;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Borrow> BookBorrows { get; set; }
        public virtual DbSet<BookDetails> BookDetails { get; set; }
        public virtual DbSet<BookTag> BookTags { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BorrowCheckoutItem> BorrowCheckoutItems { get; set; }
        public virtual DbSet<BorrowCheckout> BorrowCheckouts { get; set; }
        public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PermissionPolicy> PermissionPolicies { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
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
            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RequestIssuerId)
                    .HasName("book_borrows_users_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RequestDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.RequestIssuerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Issuer)
                    .WithMany(p => p.IssuedBorrows)
                    .HasForeignKey(d => d.RequestIssuerId)
                    .HasConstraintName("book_borrows_users_fk");
            });

            modelBuilder.Entity<BookDetails>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("book_details_books_fk_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("'uuid()'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BookId)
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

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_details_books_fk");
            });

            modelBuilder.Entity<BookTag>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("book_tags_books_fk_idx1");

                entity.HasIndex(e => e.TagId)
                    .HasName("book_tags_books_fk_idx");

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
                    .HasConstraintName("book_tags_books_fk");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BookTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_tags_tags_fk");
            });

            modelBuilder.Entity<Book>(entity =>
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
                    .WithMany(p => p.BooksAdded)
                    .HasForeignKey(d => d.AdderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("books_users_fk_adder");
            });

            modelBuilder.Entity<BorrowCheckoutItem>(entity =>
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
                    .WithMany(p => p.CheckoutItems)
                    .HasForeignKey(d => d.CheckoutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("borrow_checkout_items_borrow_checkouts_fk");
            });

            modelBuilder.Entity<BorrowCheckout>(entity =>
            {
                entity.HasIndex(e => e.BorrowId)
                    .HasName("book_borrows_borrow_checkouts_fk_idx");

                entity.HasIndex(e => e.CheckoutIssuerId)
                    .HasName("book_checkout_issuer_users_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BorrowId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckoutIssuerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckoutRequestDate).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Borrow)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.BorrowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_borrows_borrow_checkouts_fk");

                entity.HasOne(d => d.CheckoutIssuer)
                    .WithMany(p => p.BorrowCheckoutsIssued)
                    .HasForeignKey(d => d.CheckoutIssuerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_checkout_issuer_users_fk");
            });

            modelBuilder.Entity<CustomerSubscription>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("customer_subscriptions_customers_fk_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("customer_subscriptions_subscription_fk_idx");

                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustomerId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateRequested).HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.HasBeenNotifiedForExpiration).HasDefaultValueSql("b'0'");

                entity.Property(e => e.ShouldNotifyForExpiration).HasDefaultValueSql("b'1'");

                entity.Property(e => e.Status)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SubscriptionId)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_subscriptions_customers_fk");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customer_subscriptions_subscription_fk");
            });

            modelBuilder.Entity<Customer>(entity =>
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
            });

            modelBuilder.Entity<PermissionPolicy>(entity =>
            {
                entity.HasIndex(e => e.PermissionId)
                    .HasName("permission_policies_permissions_fk_idx");

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
                    .HasConstraintName("permission_policies_permissions_fk");
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

            modelBuilder.Entity<SubscriptionPermission>(entity =>
            {
                entity.HasIndex(e => e.PermissionId)
                    .HasName("subscription_permisions_permissions_fk_idx");

                entity.HasIndex(e => e.SubscriptionId)
                    .HasName("subscription_permissions_subscription_fk_idx");

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
                    .HasConstraintName("subscription_permisions_permissions_fk");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionPermissions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscription_permissions_subscription_fk");
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
                entity.Property(e => e.Id)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
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
