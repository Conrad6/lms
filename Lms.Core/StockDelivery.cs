using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("stock_deliveries")]
    public partial class StockDelivery
    {
        public StockDelivery()
        {
            StockDeliveryItems = new HashSet<StockDeliveryItem>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("quantity", TypeName = "int(11)")]
        public int? Quantity { get; set; }

        [Column("delivery_date", TypeName = "timestamp")]
        public DateTime DeliveryDate { get; set; }

        [Required]
        [Column("stock_id", TypeName = "varchar(36)")]
        public string StockId { get; set; }

        [Required]
        [Column("recepient_id", TypeName = "varchar(36)")]
        public string RecepientId { get; set; }

        [ForeignKey(nameof(RecepientId))]
        [InverseProperty(nameof(User.StockDeliveries))]
        public virtual User Recepient { get; set; }

        [ForeignKey(nameof(StockId))]
        [InverseProperty(nameof(Core.Stock.StockDeliveries))]
        public virtual Stock Stock { get; set; }

        [InverseProperty("StockDelivery")] public virtual ICollection<StockDeliveryItem> StockDeliveryItems { get; }
    }
}