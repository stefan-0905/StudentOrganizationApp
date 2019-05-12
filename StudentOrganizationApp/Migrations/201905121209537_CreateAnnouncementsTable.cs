namespace StudentOrganizationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAnnouncementsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Announcements");
        }
    }
}
