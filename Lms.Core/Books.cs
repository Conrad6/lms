using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("books")]
    public partial class Books
    {
        public Books()
        {
            BookDetails = new HashSet<BookDetails>();
            BookTags = new HashSet<BookTags>();
            BorrowCheckoutItems = new HashSet<BorrowCheckoutItems>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("author", TypeName = "varchar(255)")]
        public string Author { get; set; }
        [Column("description", TypeName = "longtext")]
        public string Description { get; set; }
        [Required]
        [Column("isbn", TypeName = "varchar(30)")]
        public string Isbn { get; set; }
        [Column("date_added", TypeName = "timestamp")]
        public DateTime DateAdded { get; set; }
        [Column("last_updated", TypeName = "timestamp")]
        public DateTime? LastUpdated { get; set; }
        [Column("genre", TypeName = "varchar(200)")]
        public string Genre { get; set; }
        [Required]
        [Column("adder_id", TypeName = "varchar(36)")]
        public string AdderId { get; set; }
        [Column("available", TypeName = "bit(1)")]
        public ulong? Available { get; set; }
        [Column("copies_available", TypeName = "int(11)")]
        public int CopiesAvailable { get; set; }
        [Column("total_copies", TypeName = "int(11)")]
        public int TotalCopies { get; set; }

        [ForeignKey(nameof(AdderId))]
        [InverseProperty(nameof(Users.Books))]
        public virtual Users Adder { get; set; }
        [InverseProperty("BookNavigation")]
        public virtual ICollection<BookDetails> BookDetails { get; set; }
        [InverseProperty("BookNavigation")]
        public virtual ICollection<BookTags> BookTags { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<BorrowCheckoutItems> BorrowCheckoutItems { get; set; }
    }
}
