namespace DimaMaster.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CarService> CarServices { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarService>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.CarService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarService>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.CarService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarService>()
                .HasMany(e => e.Services)
                .WithMany(e => e.CarServices)
                .Map(m => m.ToTable("CarServiceToService").MapLeftKey("CarServiceId").MapRightKey("ServiceId"));

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Place>()
                .HasMany(e => e.CarServices)
                .WithRequired(e => e.Place)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);
        }
    }
}
