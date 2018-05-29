namespace Models.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductID { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên sản phẩm:")]
        public string Name { get; set; }
        [Display(Name = "Ðặc trưng:")]

        public int? Code { get; set; }
        [Display(Name = "Thông điệp:")]

        public string Description { get; set; }
        [Display(Name = "Chi tiết sản phẩm:")]

        public string Detail { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Hình ảnh:")]
        public string Image { get; set; }
        [Display(Name = "Giá sản phẩm:")]

        public double? Price { get; set; }
        [Display(Name = "Giá khuyến mãi:")]

        public double? PromotionPrice { get; set; }
        [Display(Name = "Số lượng:")]

        public int? Quantity { get; set; }

        [StringLength(500)]

        public string MetaTitle { get; set; }
        [Display(Name = "Danh mục:")]

        public int? CategoryID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ViewCount { get; set; }
        [Display(Name = "Trạng thái:")]
        public bool? Status
        {
            get; set;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
