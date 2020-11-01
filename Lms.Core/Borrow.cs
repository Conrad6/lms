using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("book_borrows")]
    public partial class Borrow
    {
        public Borrow()
        {
            Checkouts = new HashSet<BorrowCheckout>();
        }

        [Key]
        [Column("borrow_id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("request_date", TypeName = "timestamp")]
        public DateTime RequestDate { get; set; }

        [Column("checkout_date", TypeName = "timestamp")]
        public DateTime? CheckoutDate { get; set; }

        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }

        [Column("request_issuer", TypeName = "varchar(36)")]
        public string RequestIssuerId { get; set; }

        [ForeignKey(nameof(RequestIssuerId))]
        [InverseProperty(nameof(User.IssuedBorrows))]
        public virtual User Issuer { get; set; }

        [InverseProperty("Borrow")] public virtual ICollection<BorrowCheckout> Checkouts { get; }
    }
}