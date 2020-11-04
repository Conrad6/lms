using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("borrow_checkout_items")]
    public partial class BorrowCheckoutItem
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("requested_copies", TypeName = "int(11)")]
        public int RequestedCopies { get; set; }

        [Column("checkedout_copies", TypeName = "int(11)")]
        public int CheckedoutCopies { get; set; }

        [Column("returned_copies", TypeName = "int(11)")]
        public int ReturnedCopies { get; set; }

        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }

        [Required]
        [Column("borrow_checkout_id", TypeName = "varchar(36)")]
        public string BorrowCheckoutId { get; set; }

        [Required]
        [Column("book_id", TypeName = "varchar(36)")]
        public string BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Core.Book.BorrowCheckoutItems))]
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(BorrowCheckoutId))]
        [InverseProperty(nameof(Core.BorrowCheckout.BorrowCheckoutItems))]
        public virtual BorrowCheckout BorrowCheckout { get; set; }
    }
}