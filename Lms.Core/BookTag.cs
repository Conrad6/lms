using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("book_tags")]
    public partial class BookTag
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [Column("book_id", TypeName = "varchar(36)")]
        public string BookId { get; set; }

        [Required]
        [Column("tag_id", TypeName = "varchar(36)")]
        public string TagId { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty(nameof(Core.Book.BookTags))]
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(TagId))]
        [InverseProperty(nameof(Core.Tag.BookTags))]
        public virtual Tag Tag { get; set; }
    }
}