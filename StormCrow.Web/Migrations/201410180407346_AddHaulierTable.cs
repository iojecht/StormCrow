using System.Data.Entity.Migrations;

namespace StormCrow.Web.Migrations
{
    public partial class AddHaulierTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hauliers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HaulierCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hauliers");
        }
    }
}
