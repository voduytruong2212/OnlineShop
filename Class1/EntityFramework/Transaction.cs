namespace Class1.EntityFramework
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
            Oders = new HashSet<Oder>();
        }

        public int TransactionID { get; set; }

        public bool? Status { get; set; }

        [Column("User-ID")]
        public int? User_ID { get; set; }

        [Column("User-Name")]
        [StringLength(50)]
        public string User_Name { get; set; }

        [Column("User-Email")]
        [StringLength(50)]
        public string User_Email { get; set; }

        [Column("User-Phone")]
        [StringLength(50)]
        public string User_Phone { get; set; }

        public double? Amount { get; set; }

        [StringLength(50)]
        public string Payment { get; set; }

        [Column(TypeName = "text")]
        public string PaymentInfo { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        [StringLength(50)]
        public string Security { get; set; }

        public DateTime? CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oder> Oders { get; set; }

        public virtual User User { get; set; }
    }
}
