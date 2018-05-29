namespace Class1.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Oder
    {
        [Key]
        public int OrderID { get; set; }

        public int? TransactionID { get; set; }

        public int? ProductID { get; set; }

        public decimal? Quantity { get; set; }

        public double? Amount { get; set; }

        public bool? Status { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
