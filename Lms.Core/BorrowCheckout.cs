using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("borrow_checkouts")]
    public partial class BorrowCheckout
    {
        public BorrowCheckout()
        {
            CheckoutItems = new HashSet<BorrowCheckoutItem>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [Column("borrow_id", TypeName = "varchar(36)")]
        public string BorrowId { get; set; }

        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }

        [Required]
        [Column("checkout_issuer", TypeName = "varchar(36)")]
        public string CheckoutIssuerId { get; set; }

        [Column("checkout_date", TypeName = "timestamp")]
        public DateTime? CheckoutDate { get; set; }

        [Column("checkout_request_date", TypeName = "timestamp")]
        public DateTime CheckoutRequestDate { get; set; }

        [Column("return_date", TypeName = "timestamp")]
        public DateTime? ReturnDate { get; set; }

        [ForeignKey(nameof(BorrowId))]
        [InverseProperty(nameof(Core.Borrow.Checkouts))]
        public virtual Borrow Borrow { get; set; }

        [ForeignKey(nameof(CheckoutIssuerId))]
        [InverseProperty(nameof(User.BorrowCheckoutsIssued))]
        public virtual User CheckoutIssuer { get; set; }

        [InverseProperty("Checkout")] public virtual ICollection<BorrowCheckoutItem> CheckoutItems { get; }
    }
}