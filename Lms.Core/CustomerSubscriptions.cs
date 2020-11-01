using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("customer_subscriptions")]
    public partial class CustomerSubscriptions
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("customer", TypeName = "varchar(36)")]
        public string Customer { get; set; }
        [Required]
        [Column("subscription", TypeName = "varchar(36)")]
        public string Subscription { get; set; }
        [Column("date_requested", TypeName = "timestamp")]
        public DateTime DateRequested { get; set; }
        [Required]
        [Column("status", TypeName = "varchar(45)")]
        public string Status { get; set; }
        [Column("expiration_date", TypeName = "timestamp")]
        public DateTime? ExpirationDate { get; set; }
        [Column("has_been_notified_for_expiration", TypeName = "bit(1)")]
        public ulong? HasBeenNotifiedForExpiration { get; set; }
        [Column("notify_after", TypeName = "date")]
        public DateTime? NotifyAfter { get; set; }
        [Column("should_notify_for_expiration", TypeName = "bit(1)")]
        public ulong? ShouldNotifyForExpiration { get; set; }

        [ForeignKey(nameof(Customer))]
        [InverseProperty(nameof(Customers.CustomerSubscriptions))]
        public virtual Customers CustomerNavigation { get; set; }
        [ForeignKey(nameof(Subscription))]
        [InverseProperty(nameof(Subscriptions.CustomerSubscriptions))]
        public virtual Subscriptions SubscriptionNavigation { get; set; }
    }
}
