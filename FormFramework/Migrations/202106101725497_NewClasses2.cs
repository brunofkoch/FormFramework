namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewClasses2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipes", "Tipo_User", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipes", "Tipo_User");
        }
    }
}
