namespace DimaMaster.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int ServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Vendor { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreate { get; set; }

        public int CarId { get; set; }

        public int EmployeeId { get; set; }
        
        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Service Service { get; set; }
    }
}
