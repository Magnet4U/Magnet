namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mootaz_UpdateQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "GroupingId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "GroupingId");
        }
    }
}
