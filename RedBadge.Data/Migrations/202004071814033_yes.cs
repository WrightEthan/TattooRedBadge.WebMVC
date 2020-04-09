namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tattoo", "ClientID", "dbo.Client");
            DropIndex("dbo.Tattoo", new[] { "ClientID" });
            AlterColumn("dbo.Tattoo", "ClientID", c => c.Int());
            CreateIndex("dbo.Tattoo", "ClientID");
            AddForeignKey("dbo.Tattoo", "ClientID", "dbo.Client", "ClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tattoo", "ClientID", "dbo.Client");
            DropIndex("dbo.Tattoo", new[] { "ClientID" });
            AlterColumn("dbo.Tattoo", "ClientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tattoo", "ClientID");
            AddForeignKey("dbo.Tattoo", "ClientID", "dbo.Client", "ClientID", cascadeDelete: true);
        }
    }
}
