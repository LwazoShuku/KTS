namespace KTS.Migrations.KtsStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "sessionUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "sessionUser");
        }
    }
}
