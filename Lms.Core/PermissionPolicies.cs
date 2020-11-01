using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("permission_policies")]
    public partial class PermissionPolicies
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Column("borrow_limit", TypeName = "int(11)")]
        public int? BorrowLimit { get; set; }
        [Column("account_limit", TypeName = "int(11)")]
        public int? AccountLimit { get; set; }
        [Required]
        [Column("permission", TypeName = "varchar(36)")]
        public string Permission { get; set; }
        [Column("checkout_limit", TypeName = "int(11)")]
        public int? CheckoutLimit { get; set; }

        [ForeignKey(nameof(Permission))]
        [InverseProperty(nameof(Permissions.PermissionPolicies))]
        public virtual Permissions PermissionNavigation { get; set; }
    }
}
