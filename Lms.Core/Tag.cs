using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("tags")]
    public partial class Tag
    {
        public Tag()
        {
            BookTags = new HashSet<BookTag>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(45)")]
        public string Name { get; set; }

        [InverseProperty("Tag")] public virtual ICollection<BookTag> BookTags { get; }
    }
}