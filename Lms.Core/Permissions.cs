using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("permissions")]
    public partial class Permissions
    {
        public Permissions()
        {
            PermissionPolicies = new HashSet<PermissionPolicies>();
            SubscriptionPermissions = new HashSet<SubscriptionPermissions>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("display_name", TypeName = "varchar(45)")]
        public string DisplayName { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(45)")]
        public string Name { get; set; }
        [Required]
        [Column("normalized_name", TypeName = "varchar(45)")]
        public string NormalizedName { get; set; }

        [InverseProperty("PermissionNavigation")]
        public virtual ICollection<PermissionPolicies> PermissionPolicies { get; set; }
        [InverseProperty("PermissionNavigation")]
        public virtual ICollection<SubscriptionPermissions> SubscriptionPermissions { get; set; }
    }
}
