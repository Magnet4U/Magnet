namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghadauser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "cin");
            DropColumn("dbo.Users", "firstname");
            DropColumn("dbo.Users", "lastname");
            DropColumn("dbo.Users", "telephone");
            DropColumn("dbo.Users", "email");
            DropColumn("dbo.Users", "experience_prof");
            DropColumn("dbo.Users", "formation");
            DropColumn("dbo.Users", "certification");
            DropColumn("dbo.Users", "liste_activite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "liste_activite", c => c.String());
            AddColumn("dbo.Users", "certification", c => c.String());
            AddColumn("dbo.Users", "formation", c => c.String());
            AddColumn("dbo.Users", "experience_prof", c => c.String());
            AddColumn("dbo.Users", "email", c => c.String());
            AddColumn("dbo.Users", "telephone", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "lastname", c => c.String());
            AddColumn("dbo.Users", "firstname", c => c.String());
            AddColumn("dbo.Users", "cin", c => c.Int(nullable: false));
        }
    }
}
