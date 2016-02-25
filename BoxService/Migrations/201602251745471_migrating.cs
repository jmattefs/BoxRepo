namespace BoxService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Description = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Box_Id = c.Int(),
                        RegisteredUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boxes", t => t.Box_Id)
                .ForeignKey("dbo.RegisteredUsers", t => t.RegisteredUser_ID)
                .Index(t => t.Box_Id)
                .Index(t => t.RegisteredUser_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boxes", "RegisteredUser_ID", "dbo.RegisteredUsers");
            DropForeignKey("dbo.Boxes", "Box_Id", "dbo.Boxes");
            DropIndex("dbo.Boxes", new[] { "RegisteredUser_ID" });
            DropIndex("dbo.Boxes", new[] { "Box_Id" });
            DropTable("dbo.Boxes");
        }
    }
}
