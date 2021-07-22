namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_changeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "SkillName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "SkillName", c => c.String());
        }
    }
}
