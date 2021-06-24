namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InplementClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leituras",
                c => new
                    {
                        LeituraID = c.Int(nullable: false, identity: true),
                        L1 = c.Single(nullable: false),
                        L2 = c.Single(nullable: false),
                        L3 = c.Single(nullable: false),
                        L4 = c.Single(nullable: false),
                        Media = c.Single(nullable: false),
                        DescMedVeiculo_DescMedID = c.Int(),
                        ModProvas_ModProvaID = c.Int(),
                    })
                .PrimaryKey(t => t.LeituraID)
                .ForeignKey("dbo.DescMeds", t => t.DescMedVeiculo_DescMedID)
                .ForeignKey("dbo.ModProvas", t => t.ModProvas_ModProvaID)
                .Index(t => t.DescMedVeiculo_DescMedID)
                .Index(t => t.ModProvas_ModProvaID);
            
            CreateTable(
                "dbo.ModProvas",
                c => new
                    {
                        ModProvaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DescProva = c.String(),
                    })
                .PrimaryKey(t => t.ModProvaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leituras", "ModProvas_ModProvaID", "dbo.ModProvas");
            DropForeignKey("dbo.Leituras", "DescMedVeiculo_DescMedID", "dbo.DescMeds");
            DropIndex("dbo.Leituras", new[] { "ModProvas_ModProvaID" });
            DropIndex("dbo.Leituras", new[] { "DescMedVeiculo_DescMedID" });
            DropTable("dbo.ModProvas");
            DropTable("dbo.Leituras");
        }
    }
}
