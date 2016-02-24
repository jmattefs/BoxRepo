namespace BoxService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        ShippingAddress = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SurveyModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        gender = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        maxMoney = c.Int(nullable: false),
                        alcohol = c.Boolean(nullable: false),
                        presentable = c.Boolean(nullable: false),
                        books = c.Boolean(nullable: false),
                        candles = c.Boolean(nullable: false),
                        candy = c.Boolean(nullable: false),
                        clothes = c.Boolean(nullable: false),
                        coffee = c.Boolean(nullable: false),
                        fitness = c.Boolean(nullable: false),
                        games = c.Boolean(nullable: false),
                        movies = c.Boolean(nullable: false),
                        music = c.Boolean(nullable: false),
                        sports = c.Boolean(nullable: false),
                        active = c.Int(nullable: false),
                        candle = c.Int(nullable: false),
                        entertainment = c.Int(nullable: false),
                        foodORdrink = c.Int(nullable: false),
                        appearance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserSubscriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubscriptionCost = c.Int(nullable: false),
                        TotalSubscriptionCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserSubscriptions");
            DropTable("dbo.SurveyModels");
            DropTable("dbo.RegisteredUsers");
        }
    }
}
