namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadaFKcareer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Careers", "MyCondidat_idUser", c => c.Int());
            CreateIndex("dbo.Careers", "MyCondidat_idUser");
            AddForeignKey("dbo.Careers", "MyCondidat_idUser", "dbo.Condidat", "idUser");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Careers", "MyCondidat_idUser", "dbo.Condidat");
            DropIndex("dbo.Careers", new[] { "MyCondidat_idUser" });
            DropColumn("dbo.Careers", "MyCondidat_idUser");
        }
    }
}
