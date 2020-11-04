using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("books")]
    public partial class Book
    {
        public Book()
        {
            BookTags = new HashSet<BookTag>();
            BorrowCheckoutItems = new HashSet<BorrowCheckoutItem>();
            StockDeliveryItems = new HashSet<StockDeliveryItem>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [Column("author", TypeName = "varchar(255)")]
        public string Author { get; set; }

        [Column("description", TypeName = "longtext")]
        public string Description { get; set; }

        [Column("isbn", TypeName = "varchar(30)")]
        public string Isbn { get; set; }

        [Column("date_added", TypeName = "timestamp")]
        public DateTime DateAdded { get; set; }

        [Column("last_updated", TypeName = "timestamp")]
        public DateTime? LastUpdated { get; set; }

        [Column("genre", TypeName = "varchar(200)")]
        public string Genre { get; set; }

        [Column("available")] public bool? Available { get; set; }

        [Column("copies_available", TypeName = "int(11)")]
        public int CopiesAvailable { get; set; }

        [Column("total_copies", TypeName = "int(11)")]
        public int TotalCopies { get; set; }

        [Required]
        [Column("book_details_id", TypeName = "varchar(36)")]
        public string BookDetailsId { get; set; }

        [Required]
        [Column("adder_id", TypeName = "varchar(36)")]
        public string AdderId { get; set; }

        [ForeignKey(nameof(AdderId))]
        [InverseProperty(nameof(User.Books))]
        public virtual User Adder { get; set; }

        [ForeignKey(nameof(BookDetailsId))]
        [InverseProperty("Books")]
        public virtual BookDetails BookDetails { get; set; }

        [InverseProperty("Book")] public virtual ICollection<BookTag> BookTags { get; }
        [InverseProperty("Book")] public virtual ICollection<BorrowCheckoutItem> BorrowCheckoutItems { get; }
        [InverseProperty("Book")] public virtual ICollection<StockDeliveryItem> StockDeliveryItems { get; }
    }
}