namespace DimaMaster.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderId { get; set; }

        public int ServiceId { get; set; }

        public int CarServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Vendor { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreate { get; set; }

        public int ClientId { get; set; }

        public int EmployeeId { get; set; }

        public virtual CarService CarService { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Service Service { get; set; }
    }
}
