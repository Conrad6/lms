using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("customers")]
    public partial class Customers
    {
        public Customers()
        {
            CustomerSubscriptions = new HashSet<CustomerSubscriptions>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Required]
        [Column("names", TypeName = "varchar(45)")]
        public string Names { get; set; }
        [Column("date_added", TypeName = "timestamp")]
        public DateTime DateAdded { get; set; }
        [Column("last_updated", TypeName = "timestamp")]
        public DateTime? LastUpdated { get; set; }
        [Column("date_of_birth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [Column("phone", TypeName = "varchar(45)")]
        public string Phone { get; set; }
        [Required]
        [Column("email", TypeName = "varchar(45)")]
        public string Email { get; set; }
        [Required]
        [Column("nat_id", TypeName = "varchar(9)")]
        public string NatId { get; set; }
        [Required]
        [Column("subscription", TypeName = "varchar(36)")]
        public string Subscription { get; set; }

        [InverseProperty("CustomerNavigation")]
        public virtual ICollection<CustomerSubscriptions> CustomerSubscriptions { get; set; }
    }
}
