namespace FormFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Descricaos", "Veiculo_VeiculoID", "dbo.Veiculoes");
            DropForeignKey("dbo.Medidas", "Descricao_DescricaoID", "dbo.Descricaos");
            DropForeignKey("dbo.VersaoVeiculoes", "Descricao_DescricaoID", "dbo.Descricaos");
            DropForeignKey("dbo.VersaoVeiculoes", "Medida_MedidaID", "dbo.Medidas");
            DropForeignKey("dbo.VersaoVeiculoes", "Veiculo_VeiculoID", "dbo.Veiculoes");
            DropIndex("dbo.Descricaos", new[] { "Veiculo_VeiculoID" });
            DropIndex("dbo.Medidas", new[] { "Descricao_DescricaoID" });
            DropIndex("dbo.VersaoVeiculoes", new[] { "Descricao_DescricaoID" });
            DropIndex("dbo.VersaoVeiculoes", new[] { "Medida_MedidaID" });
            DropIndex("dbo.VersaoVeiculoes", new[] { "Veiculo_VeiculoID" });
            DropTable("dbo.Descricaos");
            DropTable("dbo.Medidas");
            DropTable("dbo.VersaoVeiculoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VersaoVeiculoes",
                c => new
                    {
                        VersaoVeiculoID = c.Int(nullable: false, identity: true),
                        FlagVersao = c.Int(nullable: false),
                        DataVersao = c.DateTime(nullable: false),
                        Descricao_DescricaoID = c.Int(),
                        Medida_MedidaID = c.Int(),
                        Veiculo_VeiculoID = c.Int(),
                    })
                .PrimaryKey(t => t.VersaoVeiculoID);
            
            CreateTable(
                "dbo.Medidas",
                c => new
                    {
                        MedidaID = c.Int(nullable: false, identity: true),
                        DiametroRodas = c.Single(nullable: false),
                        AlturaTotalVeiculo = c.Single(nullable: false),
                        AlturaDoChao = c.Single(nullable: false),
                        LarguraVeiculo = c.Single(nullable: false),
                        ComprimentoVeiculo = c.Single(nullable: false),
                        Passo = c.Single(nullable: false),
                        BitolaDianteira = c.Single(nullable: false),
                        BitolaTraseira = c.Single(nullable: false),
                        PessoTotalVeiculo = c.Single(nullable: false),
                        Descricao_DescricaoID = c.Int(),
                    })
                .PrimaryKey(t => t.MedidaID);
            
            CreateTable(
                "dbo.Descricaos",
                c => new
                    {
                        DescricaoID = c.Int(nullable: false, identity: true),
                        TipoVeiculo = c.String(),
                        MatCarroceria = c.String(),
                        CorCarroceria = c.String(),
                        QtdRodas = c.Int(nullable: false),
                        VoltControle = c.Int(nullable: false),
                        VoltMotor = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        UltimaModificacao = c.DateTime(nullable: false),
                        Veiculo_VeiculoID = c.Int(),
                    })
                .PrimaryKey(t => t.DescricaoID);
            
            CreateIndex("dbo.VersaoVeiculoes", "Veiculo_VeiculoID");
            CreateIndex("dbo.VersaoVeiculoes", "Medida_MedidaID");
            CreateIndex("dbo.VersaoVeiculoes", "Descricao_DescricaoID");
            CreateIndex("dbo.Medidas", "Descricao_DescricaoID");
            CreateIndex("dbo.Descricaos", "Veiculo_VeiculoID");
            AddForeignKey("dbo.VersaoVeiculoes", "Veiculo_VeiculoID", "dbo.Veiculoes", "VeiculoID");
            AddForeignKey("dbo.VersaoVeiculoes", "Medida_MedidaID", "dbo.Medidas", "MedidaID");
            AddForeignKey("dbo.VersaoVeiculoes", "Descricao_DescricaoID", "dbo.Descricaos", "DescricaoID");
            AddForeignKey("dbo.Medidas", "Descricao_DescricaoID", "dbo.Descricaos", "DescricaoID");
            AddForeignKey("dbo.Descricaos", "Veiculo_VeiculoID", "dbo.Veiculoes", "VeiculoID");
        }
    }
}
