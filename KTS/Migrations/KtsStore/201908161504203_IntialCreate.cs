namespace KTS.Migrations.KtsStore
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "BankAccNo", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "BranchCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "BranchCode");
            DropColumn("dbo.Employees", "BankAccNo");
        }
    }
}
