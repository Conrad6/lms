using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("subscription_permissions")]
    public partial class SubscriptionPermission
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Required]
        [Column("subscription", TypeName = "varchar(36)")]
        public string SubscriptionId { get; set; }

        [Required]
        [Column("permission", TypeName = "varchar(36)")]
        public string PermissionId { get; set; }

        [ForeignKey(nameof(Core.Permission))]
        [InverseProperty(nameof(Core.Permission.SubscriptionPermissions))]
        public virtual Permission Permission { get; set; }

        [ForeignKey(nameof(SubscriptionId))]
        [InverseProperty(nameof(Core.Subscription.SubscriptionPermissions))]
        public virtual Subscription Subscription { get; set; }
    }
}