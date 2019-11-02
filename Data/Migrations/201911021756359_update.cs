namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "cin", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "firstname", c => c.String());
            AddColumn("dbo.Users", "lastname", c => c.String());
            AddColumn("dbo.Users", "telephone", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "email", c => c.String());
            DropColumn("dbo.Condidat", "cin");
            DropColumn("dbo.Condidat", "telephone");
            DropColumn("dbo.Condidat", "email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Condidat", "email", c => c.String());
            AddColumn("dbo.Condidat", "telephone", c => c.Int(nullable: false));
            AddColumn("dbo.Condidat", "cin", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "email");
            DropColumn("dbo.Users", "telephone");
            DropColumn("dbo.Users", "lastname");
            DropColumn("dbo.Users", "firstname");
            DropColumn("dbo.Users", "cin");
        }
    }
}
