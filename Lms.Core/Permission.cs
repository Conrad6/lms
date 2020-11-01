using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("permissions")]
    public partial class Permission
    {
        public Permission()
        {
            PermissionPolicies = new HashSet<PermissionPolicy>();
            SubscriptionPermissions = new HashSet<SubscriptionPermission>();
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

        [InverseProperty("Permission")]
        public virtual ICollection<PermissionPolicy> PermissionPolicies { get; }

        [InverseProperty("Permission")]
        public virtual ICollection<SubscriptionPermission> SubscriptionPermissions { get; }
    }
}