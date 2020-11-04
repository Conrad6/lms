using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("permission_policies")]
    public partial class PermissionPolicy
    {
        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }

        [Column("borrow_limit", TypeName = "int(11)")]
        public int? BorrowLimit { get; set; }

        [Column("account_limit", TypeName = "int(11)")]
        public int? AccountLimit { get; set; }

        [Column("checkout_limit", TypeName = "int(11)")]
        public int? CheckoutLimit { get; set; }

        [Required]
        [Column("permission_id", TypeName = "varchar(36)")]
        public string PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty(nameof(Core.Permission.PermissionPolicies))]
        public virtual Permission Permission { get; set; }
    }
}