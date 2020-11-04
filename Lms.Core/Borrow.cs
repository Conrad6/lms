using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("borrows")]
    public partial class Borrow
    {
        public Borrow()
        {
            BorrowCheckouts = new HashSet<BorrowCheckout>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("request_date", TypeName = "timestamp")]
        public DateTime RequestDate { get; set; }

        [Column("checkout_date", TypeName = "timestamp")]
        public DateTime? CheckoutDate { get; set; }

        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }

        [Required]
        [Column("issuer_id", TypeName = "varchar(36)")]
        public string IssuerId { get; set; }

        [Required]
        [Column("customer_id", TypeName = "varchar(36)")]
        public string CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Core.Customer.Borrows))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(IssuerId))]
        [InverseProperty(nameof(User.Borrows))]
        public virtual User Issuer { get; set; }

        [InverseProperty("Borrow")] public virtual ICollection<BorrowCheckout> BorrowCheckouts { get; }
    }
}