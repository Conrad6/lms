using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("subscription_permissions")]
    public partial class SubscriptionPermissions
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("subscription", TypeName = "varchar(36)")]
        public string Subscription { get; set; }
        [Required]
        [Column("permission", TypeName = "varchar(36)")]
        public string Permission { get; set; }

        [ForeignKey(nameof(Permission))]
        [InverseProperty(nameof(Permissions.SubscriptionPermissions))]
        public virtual Permissions PermissionNavigation { get; set; }
        [ForeignKey(nameof(Subscription))]
        [InverseProperty(nameof(Subscriptions.SubscriptionPermissions))]
        public virtual Subscriptions SubscriptionNavigation { get; set; }
    }
}
