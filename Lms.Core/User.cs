using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("users")]
    public partial class User
    {
        public User()
        {
            IssuedBorrows = new HashSet<Borrow>();
            BooksAdded = new HashSet<Book>();
            BorrowCheckoutsIssued = new HashSet<BorrowCheckout>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("first_name", TypeName = "varchar(45)")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(45)")]
        public string LastName { get; set; }

        [Required]
        [Column("gender", TypeName = "varchar(6)")]
        public string Gender { get; set; }

        [Required]
        [Column("username", TypeName = "varchar(45)")]
        public string Username { get; set; }

        [Column("email", TypeName = "varchar(45)")]
        public string Email { get; set; }

        [Column("phone", TypeName = "varchar(45)")]
        public string Phone { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column("avatar", TypeName = "varchar(255)")]
        public string Avatar { get; set; }

        [Column("date_created", TypeName = "timestamp")]
        public DateTime? DateCreated { get; set; }

        [Column("last_updated", TypeName = "timestamp")]
        public DateTime? LastUpdated { get; set; }

        [InverseProperty("Issuer")]
        public virtual ICollection<Borrow> IssuedBorrows { get; }

        [InverseProperty("Adder")] public virtual ICollection<Book> BooksAdded { get; }

        [InverseProperty("CheckoutIssuer")]
        public virtual ICollection<BorrowCheckout> BorrowCheckoutsIssued { get; }
    }
}