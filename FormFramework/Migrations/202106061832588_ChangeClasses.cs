namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Equipe_EquipeID = c.Int(),
                    })
                .PrimaryKey(t => t.AlunoID)
                .ForeignKey("dbo.Equipes", t => t.Equipe_EquipeID)
                .Index(t => t.Equipe_EquipeID);
            
            CreateTable(
                "dbo.Equipes",
                c => new
                    {
                        EquipeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.EquipeID);
            
            CreateTable(
                "dbo.DescMeds",
                c => new
                    {
                        DescMedID = c.Int(nullable: false, identity: true),
                        Versao = c.Int(nullable: false),
                        TipoVeiculo = c.String(),
                        MatCarroceria = c.String(),
                        CorCarroceria = c.String(),
                        QtdRodas = c.Int(nullable: false),
                        VoltControle = c.Int(nullable: false),
                        VoltMotor = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        DiametroRodas = c.Single(nullable: false),
                        AlturaTotalVeiculo = c.Single(nullable: false),
                        AlturaDoChao = c.Single(nullable: false),
                        LarguraVeiculo = c.Single(nullable: false),
                        ComprimentoVeiculo = c.Single(nullable: false),
                        Passo = c.Single(nullable: false),
                        BitolaDianteira = c.Single(nullable: false),
                        BitolaTraseira = c.Single(nullable: false),
                        PessoTotalVeiculo = c.Single(nullable: false),
                        UltimaModificacao = c.DateTime(nullable: false),
                        Veiculo_VeiculoID = c.Int(),
                    })
                .PrimaryKey(t => t.DescMedID)
                .ForeignKey("dbo.Veiculoes", t => t.Veiculo_VeiculoID)
                .Index(t => t.Veiculo_VeiculoID);
            
            CreateTable(
                "dbo.Veiculoes",
                c => new
                    {
                        VeiculoID = c.Int(nullable: false, identity: true),
                        Data_Criacao = c.DateTime(nullable: false),
                        Equipe_EquipeID = c.Int(),
                    })
                .PrimaryKey(t => t.VeiculoID)
                .ForeignKey("dbo.Equipes", t => t.Equipe_EquipeID)
                .Index(t => t.Equipe_EquipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DescMeds", "Veiculo_VeiculoID", "dbo.Veiculoes");
            DropForeignKey("dbo.Veiculoes", "Equipe_EquipeID", "dbo.Equipes");
            DropForeignKey("dbo.Alunoes", "Equipe_EquipeID", "dbo.Equipes");
            DropIndex("dbo.Veiculoes", new[] { "Equipe_EquipeID" });
            DropIndex("dbo.DescMeds", new[] { "Veiculo_VeiculoID" });
            DropIndex("dbo.Alunoes", new[] { "Equipe_EquipeID" });
            DropTable("dbo.Veiculoes");
            DropTable("dbo.DescMeds");
            DropTable("dbo.Equipes");
            DropTable("dbo.Alunoes");
        }
    }
}
