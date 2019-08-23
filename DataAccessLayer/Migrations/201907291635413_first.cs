namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        OrgDate = c.DateTime(nullable: false),
                        Place = c.String(),
                        ImageUrl = c.String(),
                        Organizer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Organizer_Id)
                .Index(t => t.Organizer_Id);
            
            CreateTable(
                "dbo.OrganizationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Organizations_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organizations_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Organizations_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "Organizer_Id", "dbo.Users");
            DropForeignKey("dbo.OrganizationUsers", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.OrganizationUsers", "Organizations_Id", "dbo.Organizations");
            DropIndex("dbo.OrganizationUsers", new[] { "Users_Id" });
            DropIndex("dbo.OrganizationUsers", new[] { "Organizations_Id" });
            DropIndex("dbo.Organizations", new[] { "Organizer_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.OrganizationUsers");
            DropTable("dbo.Organizations");
        }
    }
}
