using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("book_borrows")]
    public partial class BookBorrow
    {
        public BookBorrow()
        {
            BorrowCheckouts = new HashSet<BorrowCheckouts>();
        }

        [Key]
        [Column("borrow_id", TypeName = "varchar(36)")]
        public string BorrowId { get; set; }
        [Column("request_date", TypeName = "timestamp")]
        public DateTime RequestDate { get; set; }
        [Column("checkout_date", TypeName = "timestamp")]
        public DateTime? CheckoutDate { get; set; }
        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }
        [Column("request_issuer", TypeName = "varchar(36)")]
        public string RequestIssuer { get; set; }

        [ForeignKey(nameof(RequestIssuer))]
        [InverseProperty(nameof(Users.BookBorrows))]
        public virtual Users RequestIssuerNavigation { get; set; }
        [InverseProperty("Borrow")]
        public virtual ICollection<BorrowCheckouts> BorrowCheckouts { get; set; }
    }
}
