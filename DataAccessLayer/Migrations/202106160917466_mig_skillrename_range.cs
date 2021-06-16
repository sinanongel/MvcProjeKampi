namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skillrename_range : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Range", c => c.Int(nullable: false));
            DropColumn("dbo.Skills", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.Skills", "Range");
        }
    }
}
