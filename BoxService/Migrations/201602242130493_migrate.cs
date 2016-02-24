namespace BoxService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyModels", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.SurveyModels", "Male");
            DropColumn("dbo.SurveyModels", "Female");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyModels", "Female", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyModels", "Male", c => c.Boolean(nullable: false));
            DropColumn("dbo.SurveyModels", "Gender");
        }
    }
}
