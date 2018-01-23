namespace DimaMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CarService",
            //    c => new
            //        {
            //            CarServiceId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            ShiftStart = c.Time(nullable: false, precision: 7),
            //            ShiftEnd = c.Time(nullable: false, precision: 7),
            //            PlaceId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CarServiceId)
            //    .ForeignKey("dbo.Place", t => t.PlaceId)
            //    .Index(t => t.PlaceId);
            
            //CreateTable(
            //    "dbo.Employee",
            //    c => new
            //        {
            //            EmployeeId = c.Int(nullable: false, identity: true),
            //            LFM = c.String(nullable: false),
            //            Age = c.Int(nullable: false),
            //            PhoneNumber = c.String(nullable: false, maxLength: 50),
            //            CarServiceId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.EmployeeId)
            //    .ForeignKey("dbo.CarService", t => t.CarServiceId)
            //    .Index(t => t.CarServiceId);
            
            //CreateTable(
            //    "dbo.Order",
            //    c => new
            //        {
            //            OrderId = c.Int(nullable: false, identity: true),
            //            ServiceId = c.Int(nullable: false),
            //            CarServiceId = c.Int(nullable: false),
            //            Vendor = c.String(nullable: false, maxLength: 50),
            //            DateCreate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
            //            ClientId = c.Int(nullable: false),
            //            EmployeeId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.OrderId)
            //    .ForeignKey("dbo.Clients", t => t.ClientId)
            //    .ForeignKey("dbo.Service", t => t.ServiceId)
            //    .ForeignKey("dbo.Employee", t => t.EmployeeId)
            //    .ForeignKey("dbo.CarService", t => t.CarServiceId)
            //    .Index(t => t.ServiceId)
            //    .Index(t => t.CarServiceId)
            //    .Index(t => t.ClientId)
            //    .Index(t => t.EmployeeId);
            
            //CreateTable(
            //    "dbo.Clients",
            //    c => new
            //        {
            //            ClientId = c.Int(nullable: false, identity: true),
            //            LFM = c.String(nullable: false),
            //            PhoneNumber = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ClientId);
            
            //CreateTable(
            //    "dbo.Service",
            //    c => new
            //        {
            //            ServiceId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Cost = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
            //            Description = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.ServiceId);
            
            //CreateTable(
            //    "dbo.Place",
            //    c => new
            //        {
            //            PlaceId = c.Int(nullable: false, identity: true),
            //            Address = c.String(nullable: false, maxLength: 50),
            //            GooglePlaceId = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.PlaceId);
            
            //CreateTable(
            //    "dbo.sysdiagrams",
            //    c => new
            //        {
            //            diagram_id = c.Int(nullable: false, identity: true),
            //            name = c.String(nullable: false, maxLength: 128),
            //            principal_id = c.Int(nullable: false),
            //            version = c.Int(),
            //            definition = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.diagram_id);
            
            //CreateTable(
            //    "dbo.CarServiceToService",
            //    c => new
            //        {
            //            CarServiceId = c.Int(nullable: false),
            //            ServiceId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.CarServiceId, t.ServiceId })
            //    .ForeignKey("dbo.CarService", t => t.CarServiceId, cascadeDelete: true)
            //    .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
            //    .Index(t => t.CarServiceId)
            //    .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarServiceToService", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.CarServiceToService", "CarServiceId", "dbo.CarService");
            DropForeignKey("dbo.CarService", "PlaceId", "dbo.Place");
            DropForeignKey("dbo.Order", "CarServiceId", "dbo.CarService");
            DropForeignKey("dbo.Employee", "CarServiceId", "dbo.CarService");
            DropForeignKey("dbo.Order", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Order", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.Order", "ClientId", "dbo.Clients");
            DropIndex("dbo.CarServiceToService", new[] { "ServiceId" });
            DropIndex("dbo.CarServiceToService", new[] { "CarServiceId" });
            DropIndex("dbo.Order", new[] { "EmployeeId" });
            DropIndex("dbo.Order", new[] { "ClientId" });
            DropIndex("dbo.Order", new[] { "CarServiceId" });
            DropIndex("dbo.Order", new[] { "ServiceId" });
            DropIndex("dbo.Employee", new[] { "CarServiceId" });
            DropIndex("dbo.CarService", new[] { "PlaceId" });
            DropTable("dbo.CarServiceToService");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Place");
            DropTable("dbo.Service");
            DropTable("dbo.Clients");
            DropTable("dbo.Order");
            DropTable("dbo.Employee");
            DropTable("dbo.CarService");
        }
    }
}
