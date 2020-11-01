using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("users")]
    public partial class Users
    {
        public Users()
        {
            BookBorrows = new HashSet<BookBorrow>();
            Books = new HashSet<Books>();
            BorrowCheckouts = new HashSet<BorrowCheckouts>();
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

        [InverseProperty("RequestIssuerNavigation")]
        public virtual ICollection<BookBorrow> BookBorrows { get; set; }
        [InverseProperty("Adder")]
        public virtual ICollection<Books> Books { get; set; }
        [InverseProperty("CheckoutIssuerNavigation")]
        public virtual ICollection<BorrowCheckouts> BorrowCheckouts { get; set; }
    }
}
