using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("tags")]
    public partial class Tags
    {
        public Tags()
        {
            BookTags = new HashSet<BookTags>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(45)")]
        public string Name { get; set; }

        [InverseProperty("TagNavigation")]
        public virtual ICollection<BookTags> BookTags { get; set; }
    }
}
