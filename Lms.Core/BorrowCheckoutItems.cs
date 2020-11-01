﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("borrow_checkout_items")]
    public partial class BorrowCheckoutItems
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("checkout_id", TypeName = "varchar(36)")]
        public string CheckoutId { get; set; }
        [Required]
        [Column("book_id", TypeName = "varchar(36)")]
        public string BookId { get; set; }
        [Column("requested_copies", TypeName = "int(11)")]
        public int RequestedCopies { get; set; }
        [Column("checkedout_copies", TypeName = "int(11)")]
        public int CheckedoutCopies { get; set; }
        [Column("returned_copies", TypeName = "int(11)")]
        public int ReturnedCopies { get; set; }
        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Books.BorrowCheckoutItems))]
        public virtual Books Book { get; set; }
        [ForeignKey(nameof(CheckoutId))]
        [InverseProperty(nameof(BorrowCheckouts.BorrowCheckoutItems))]
        public virtual BorrowCheckouts Checkout { get; set; }
    }
}
