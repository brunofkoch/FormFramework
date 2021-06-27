namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ModProvas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ModProvas", "NumProva", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ModProvas", "NumProva");
        }
    }
}
