using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lms.Core
{
    [Table("users")]
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
            BorrowCheckouts = new HashSet<BorrowCheckout>();
            Borrows = new HashSet<Borrow>();
            Customers = new HashSet<Customer>();
            InverseBoss = new HashSet<User>();
            StockDeliveries = new HashSet<StockDelivery>();
            Stocks = new HashSet<Stock>();
        }

        [Key]
        [Column("id", TypeName = "varchar(36)")]
        public string Id { get; set; }
        [Column("first_name", TypeName = "varchar(45)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "varchar(45)")]
        public string LastName { get; set; }
        [Required]
        [Column("gender", TypeName = "varchar(6)")]
        public string Gender { get; set; }
        [Required]
        [Column("username", TypeName = "varchar(45)")]
        public string Username { get; set; }
        [Column("email", TypeName = "varchar(45)")]
        public string Email { get; set; }
        [Column("phone", TypeName = "varchar(45)")]
        public string Phone { get; set; }
        [Required]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }
        [Column("avatar", TypeName = "varchar(255)")]
        public string Avatar { get; set; }
        [Column("date_created", TypeName = "timestamp")]
        public DateTime? DateCreated { get; set; }
        [Column("last_updated", TypeName = "timestamp")]
        public DateTime? LastUpdated { get; set; }
        [Required]
        [Column("user_role", TypeName = "varchar(25)")]
        public string UserRole { get; set; }
        [Column("boss_id", TypeName = "varchar(36)")]
        public string BossId { get; set; }

        [ForeignKey(nameof(BossId))]
        [InverseProperty(nameof(User.InverseBoss))]
        public virtual User Boss { get; set; }
        [InverseProperty("Adder")]
        public virtual ICollection<Book> Books { get;  }
        [InverseProperty("Issuer")]
        public virtual ICollection<BorrowCheckout> BorrowCheckouts { get;  }
        [InverseProperty("Issuer")]
        public virtual ICollection<Borrow> Borrows { get;  }
        [InverseProperty("Adder")]
        public virtual ICollection<Customer> Customers { get;  }
        [InverseProperty(nameof(User.Boss))]
        public virtual ICollection<User> InverseBoss { get;  }
        [InverseProperty("Recepient")]
        public virtual ICollection<StockDelivery> StockDeliveries { get;  }
        [InverseProperty("Owner")]
        public virtual ICollection<Stock> Stocks { get; }
    }
}
