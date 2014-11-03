using System.Data.Entity.Migrations;

namespace StormCrow.Web.Migrations
{
    public partial class NameChange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SettingModels", newName: "Settings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Settings", newName: "SettingModels");
        }
    }
}
