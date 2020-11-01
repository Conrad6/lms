using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("book_tags")]
    public partial class BookTags
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("book", TypeName = "varchar(36)")]
        public string Book { get; set; }
        [Required]
        [Column("tag", TypeName = "varchar(36)")]
        public string Tag { get; set; }

        [ForeignKey(nameof(Book))]
        [InverseProperty(nameof(Books.BookTags))]
        public virtual Books BookNavigation { get; set; }
        [ForeignKey(nameof(Tag))]
        [InverseProperty(nameof(Tags.BookTags))]
        public virtual Tags TagNavigation { get; set; }
    }
}
