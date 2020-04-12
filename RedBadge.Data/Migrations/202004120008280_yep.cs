namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tattoo", "ArtistID", c => c.Int());
            CreateIndex("dbo.Tattoo", "ArtistID");
            AddForeignKey("dbo.Tattoo", "ArtistID", "dbo.Artist", "ArtistID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tattoo", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Tattoo", new[] { "ArtistID" });
            DropColumn("dbo.Tattoo", "ArtistID");
        }
    }
}
