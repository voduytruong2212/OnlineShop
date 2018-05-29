namespace Models.EntityFrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public int CategoryID { get; set; }

        [StringLength(500)]
        public string CategoryName { get; set; }

        public int? ParentID { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        public bool? Status { get; set; }
    }
}
