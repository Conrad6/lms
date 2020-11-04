using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("stock_delivery_items")]
    public partial class StockDeliveryItem
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("quantity", TypeName = "int(11)")]
        public int Quantity { get; set; }

        [Required]
        [Column("stock_delivery_id", TypeName = "varchar(36)")]
        public string StockDeliveryId { get; set; }

        [Required]
        [Column("book_id", TypeName = "varchar(36)")]
        public string BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Core.Book.StockDeliveryItems))]
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(StockDeliveryId))]
        [InverseProperty(nameof(Core.StockDelivery.StockDeliveryItems))]
        public virtual StockDelivery StockDelivery { get; set; }
    }
}