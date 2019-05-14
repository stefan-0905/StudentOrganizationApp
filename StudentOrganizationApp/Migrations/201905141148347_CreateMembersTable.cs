namespace StudentOrganizationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMembersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        EnrolledAt = c.DateTime(nullable: false),
                        Email = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Members", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Members", new[] { "RoleId" });
            DropIndex("dbo.Members", new[] { "DepartmentId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Departments");
            DropTable("dbo.Members");
        }
    }
}
