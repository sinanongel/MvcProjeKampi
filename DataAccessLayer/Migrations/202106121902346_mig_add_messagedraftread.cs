namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_messagedraftread : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Draft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Read");
            DropColumn("dbo.Messages", "Draft");
        }
    }
}
