namespace DimaMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Order", "ClientId", "dbo.Clients");
            //DropForeignKey("dbo.Order", "CarServiceId", "dbo.CarService");
            DropForeignKey("dbo.CarServiceToService", "CarServiceId", "dbo.CarService");
            DropForeignKey("dbo.CarServiceToService", "ServiceId", "dbo.Service");
            DropIndex("dbo.Order", new[] { "CarServiceId" });
            DropIndex("dbo.Order", new[] { "ClientId" });
            DropIndex("dbo.CarServiceToService", new[] { "CarServiceId" });
            DropIndex("dbo.CarServiceToService", new[] { "ServiceId" });
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            AddColumn("dbo.Order", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "CarId");
            AddForeignKey("dbo.Order", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
            //DropColumn("dbo.Order", "CarServiceId");
            //DropColumn("dbo.Order", "ClientId");
            DropTable("dbo.CarServiceToService");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarServiceToService",
                c => new
                    {
                        CarServiceId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarServiceId, t.ServiceId });
            
            AddColumn("dbo.Order", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "CarServiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Order", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "ClientId", "dbo.Clients");
            DropIndex("dbo.Order", new[] { "CarId" });
            DropIndex("dbo.Cars", new[] { "ClientId" });
            DropColumn("dbo.Order", "CarId");
            DropTable("dbo.Cars");
            CreateIndex("dbo.CarServiceToService", "ServiceId");
            CreateIndex("dbo.CarServiceToService", "CarServiceId");
            CreateIndex("dbo.Order", "ClientId");
            CreateIndex("dbo.Order", "CarServiceId");
            AddForeignKey("dbo.CarServiceToService", "ServiceId", "dbo.Service", "ServiceId", cascadeDelete: true);
            AddForeignKey("dbo.CarServiceToService", "CarServiceId", "dbo.CarService", "CarServiceId", cascadeDelete: true);
            AddForeignKey("dbo.Order", "CarServiceId", "dbo.CarService", "CarServiceId");
            AddForeignKey("dbo.Order", "ClientId", "dbo.Clients", "ClientId");
        }
    }
}
