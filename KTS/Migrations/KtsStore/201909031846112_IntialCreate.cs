namespace KTS.Migrations.KtsStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ItemType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ItemType", c => c.String(nullable: false));
        }
    }
}
