namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovasClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rankings",
                c => new
                    {
                        RankingID = c.Int(nullable: false, identity: true),
                        Colocacao = c.Int(nullable: false),
                        EtapaCompeticao = c.Int(nullable: false),
                        ModProvas_ModProvaID = c.Int(),
                        Resultados_ResultadoID = c.Int(),
                    })
                .PrimaryKey(t => t.RankingID)
                .ForeignKey("dbo.ModProvas", t => t.ModProvas_ModProvaID)
                .ForeignKey("dbo.Resultadoes", t => t.Resultados_ResultadoID)
                .Index(t => t.ModProvas_ModProvaID)
                .Index(t => t.Resultados_ResultadoID);
            
            CreateTable(
                "dbo.Resultadoes",
                c => new
                    {
                        ResultadoID = c.Int(nullable: false, identity: true),
                        Pontuacao = c.Single(nullable: false),
                        Equipes_EquipeID = c.Int(),
                        Leituras_LeituraID = c.Int(),
                        ModProvas_ModProvaID = c.Int(),
                    })
                .PrimaryKey(t => t.ResultadoID)
                .ForeignKey("dbo.Equipes", t => t.Equipes_EquipeID)
                .ForeignKey("dbo.Leituras", t => t.Leituras_LeituraID)
                .ForeignKey("dbo.ModProvas", t => t.ModProvas_ModProvaID)
                .Index(t => t.Equipes_EquipeID)
                .Index(t => t.Leituras_LeituraID)
                .Index(t => t.ModProvas_ModProvaID);
            
            AddColumn("dbo.DescMeds", "link_video", c => c.String());
            AddColumn("dbo.ModProvas", "Infos", c => c.String());
            DropColumn("dbo.ModProvas", "DescProva");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ModProvas", "DescProva", c => c.String());
            DropForeignKey("dbo.Rankings", "Resultados_ResultadoID", "dbo.Resultadoes");
            DropForeignKey("dbo.Resultadoes", "ModProvas_ModProvaID", "dbo.ModProvas");
            DropForeignKey("dbo.Resultadoes", "Leituras_LeituraID", "dbo.Leituras");
            DropForeignKey("dbo.Resultadoes", "Equipes_EquipeID", "dbo.Equipes");
            DropForeignKey("dbo.Rankings", "ModProvas_ModProvaID", "dbo.ModProvas");
            DropIndex("dbo.Resultadoes", new[] { "ModProvas_ModProvaID" });
            DropIndex("dbo.Resultadoes", new[] { "Leituras_LeituraID" });
            DropIndex("dbo.Resultadoes", new[] { "Equipes_EquipeID" });
            DropIndex("dbo.Rankings", new[] { "Resultados_ResultadoID" });
            DropIndex("dbo.Rankings", new[] { "ModProvas_ModProvaID" });
            DropColumn("dbo.ModProvas", "Infos");
            DropColumn("dbo.DescMeds", "link_video");
            DropTable("dbo.Resultadoes");
            DropTable("dbo.Rankings");
        }
    }
}
