namespace StormCrow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IoC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        SerialShippingContainerCode = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CurrentQuantity = c.Double(nullable: false),
                        OriginalQuantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.SerialShippingContainerCode, t.ProductId })
                .ForeignKey("dbo.Pallet", t => t.SerialShippingContainerCode)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.SerialShippingContainerCode)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Pallet",
                c => new
                    {
                        SerialShippingContainerCode = c.Int(nullable: false, identity: true),
                        ReceiptDate = c.DateTime(),
                        ManufactureDate = c.DateTime(nullable: false),
                        BatchCode = c.String(),
                        OwnerOrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialShippingContainerCode)
                .ForeignKey("dbo.Organization", t => t.OwnerOrganizationId)
                .Index(t => t.OwnerOrganizationId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Item", "SerialShippingContainerCode", "dbo.Pallet");
            DropForeignKey("dbo.Pallet", "OwnerOrganizationId", "dbo.Organization");
            DropIndex("dbo.Pallet", new[] { "OwnerOrganizationId" });
            DropIndex("dbo.Item", new[] { "ProductId" });
            DropIndex("dbo.Item", new[] { "SerialShippingContainerCode" });
            DropTable("dbo.Product");
            DropTable("dbo.Organization");
            DropTable("dbo.Pallet");
            DropTable("dbo.Item");
        }
    }
}
