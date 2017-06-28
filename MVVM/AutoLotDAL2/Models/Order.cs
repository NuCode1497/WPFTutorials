namespace AutoLotDAL2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int CustId { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey("CustId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}
