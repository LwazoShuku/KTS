namespace KTS.Migrations.KtsStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "dateT", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Bookings", new[] { "dateT", "time", "sessionUser" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Bookings");
            AlterColumn("dbo.Bookings", "dateT", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Bookings", new[] { "dateT", "time", "sessionUser" });
        }
    }
}
