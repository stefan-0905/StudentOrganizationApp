namespace StudentOrganizationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedAtColumnToAnnouncements : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "CreatedAt");
        }
    }
}
