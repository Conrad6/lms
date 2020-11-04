using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("stocks")]
    public partial class Stock
    {
        public Stock()
        {
            BorrowCheckouts = new HashSet<BorrowCheckout>();
            StockDeliveries = new HashSet<StockDelivery>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("date_created", TypeName = "timestamp")]
        public DateTime DateCreated { get; set; }

        [Column("total_items", TypeName = "int(11)")]
        public int? TotalItems { get; set; }

        [Column("is_in_use")] public bool? IsInUse { get; set; }

        [Column("date_requested", TypeName = "timestamp")]
        public DateTime? DateRequested { get; set; }

        [Required]
        [Column("owner_id", TypeName = "varchar(36)")]
        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        [InverseProperty(nameof(User.Stocks))]
        public virtual User Owner { get; set; }

        [InverseProperty("Stock")] public virtual ICollection<BorrowCheckout> BorrowCheckouts { get; }
        [InverseProperty("Stock")] public virtual ICollection<StockDelivery> StockDeliveries { get; }
    }
}