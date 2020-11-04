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
            BorrowCheckoutItems = new HashSet<BorrowCheckoutItem>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }

        [Column("checkout_date", TypeName = "timestamp")]
        public DateTime? CheckoutDate { get; set; }

        [Column("checkout_request_date", TypeName = "timestamp")]
        public DateTime CheckoutRequestDate { get; set; }

        [Column("return_date", TypeName = "timestamp")]
        public DateTime? ReturnDate { get; set; }

        [Required]
        [Column("borrow_id", TypeName = "varchar(36)")]
        public string BorrowId { get; set; }

        [Required]
        [Column("issuer_id", TypeName = "varchar(36)")]
        public string IssuerId { get; set; }

        [Required]
        [Column("stock_id", TypeName = "varchar(36)")]
        public string StockId { get; set; }

        [ForeignKey(nameof(BorrowId))]
        [InverseProperty(nameof(Core.Borrow.BorrowCheckouts))]
        public virtual Borrow Borrow { get; set; }

        [ForeignKey(nameof(IssuerId))]
        [InverseProperty(nameof(User.BorrowCheckouts))]
        public virtual User Issuer { get; set; }

        [ForeignKey(nameof(StockId))]
        [InverseProperty(nameof(Core.Stock.BorrowCheckouts))]
        public virtual Stock Stock { get; set; }

        [InverseProperty("BorrowCheckout")] public virtual ICollection<BorrowCheckoutItem> BorrowCheckoutItems { get; }
    }
}