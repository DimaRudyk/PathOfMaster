namespace DimaMaster.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        public string Name { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();


    }
}
