namespace Models.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int UserID { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên tài khoản:")]
        public string UserName { get; set; }

        [StringLength(500)]
        [Display(Name = "Mật khẩu:")]
        public string Password { get; set; }

        [StringLength(20)]
        [Display(Name = "Loại tài khoản:")]
        public string UserTypeID { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên người dùng:")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Ðịa chỉ:")]
        public string Address { get; set; }

        [StringLength(500)]
        [Display(Name = "Ðịa chỉ Email:")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại:")]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Trạng thái:")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
