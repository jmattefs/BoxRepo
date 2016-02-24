namespace BoxService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyModels", "Male", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyModels", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyModels", "Money", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyModels", "Looks", c => c.Int(nullable: false));
            AlterColumn("dbo.SurveyModels", "Appearance", c => c.Boolean(nullable: false));
            DropColumn("dbo.SurveyModels", "gender");
            DropColumn("dbo.SurveyModels", "maxMoney");
            DropColumn("dbo.SurveyModels", "presentable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyModels", "presentable", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyModels", "maxMoney", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyModels", "gender", c => c.Int(nullable: false));
            AlterColumn("dbo.SurveyModels", "Appearance", c => c.Int(nullable: false));
            DropColumn("dbo.SurveyModels", "Looks");
            DropColumn("dbo.SurveyModels", "Money");
            DropColumn("dbo.SurveyModels", "Female");
            DropColumn("dbo.SurveyModels", "Male");
        }
    }
}
