namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addimage_file : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageFileId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        ImagePath = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ImageFileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
