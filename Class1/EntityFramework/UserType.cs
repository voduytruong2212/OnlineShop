namespace Class1.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserType")]
    public partial class UserType
    {
        public int UserTypeID { get; set; }

        [StringLength(50)]
        public string UserTypeName { get; set; }
    }
}
