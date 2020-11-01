using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("book_details")]
    public partial class BookDetails
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Column("publisher", TypeName = "varchar(45)")]
        public string Publisher { get; set; }
        [Column("weight")]
        public float? Weight { get; set; }
        [Column("page_count", TypeName = "int(11)")]
        public int? PageCount { get; set; }
        [Column("website", TypeName = "varchar(200)")]
        public string Website { get; set; }
        [Column("photo", TypeName = "varchar(200)")]
        public string Photo { get; set; }
        [Column("edition", TypeName = "varchar(45)")]
        public string Edition { get; set; }
        [Column("publish_year", TypeName = "year(4)")]
        public short? PublishYear { get; set; }
        [Required]
        [Column("book", TypeName = "varchar(36)")]
        public string Book { get; set; }

        [ForeignKey(nameof(Book))]
        [InverseProperty(nameof(Books.BookDetails))]
        public virtual Books BookNavigation { get; set; }
    }
}
