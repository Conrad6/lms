using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("subscriptions")]
    public partial class Subscriptions
    {
        public Subscriptions()
        {
            CustomerSubscriptions = new HashSet<CustomerSubscriptions>();
            SubscriptionPermissions = new HashSet<SubscriptionPermissions>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Column("display_name", TypeName = "varchar(45)")]
        public string DisplayName { get; set; }
        [Required]
        [Column("name", TypeName = "varchar(45)")]
        public string Name { get; set; }
        [Required]
        [Column("normalized_name", TypeName = "varchar(45)")]
        public string NormalizedName { get; set; }
        [Column("duration")]
        public double? Duration { get; set; }
        [Column("levy", TypeName = "decimal(10,0)")]
        public decimal Levy { get; set; }

        [InverseProperty("SubscriptionNavigation")]
        public virtual ICollection<CustomerSubscriptions> CustomerSubscriptions { get; set; }
        [InverseProperty("SubscriptionNavigation")]
        public virtual ICollection<SubscriptionPermissions> SubscriptionPermissions { get; set; }
    }
}
