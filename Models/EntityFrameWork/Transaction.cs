namespace Models.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            Orders = new HashSet<Order>();
        }

        public int TransactionID { get; set; }

        public bool? Status { get; set; }

        [Column("User-ID")]
        public int? User_ID { get; set; }

        [Column("User-Name")]
        [StringLength(500)]
        public string User_Name { get; set; }

        [Column("User-Email")]
        [StringLength(500)]
        public string User_Email { get; set; }

        [Column("User-Phone")]
        [StringLength(500)]
        public string User_Phone { get; set; }

        [Column("User-Address")]
        [StringLength(500)]
        public string User_Address { get; set; }

        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual User User { get; set; }
    }
}
