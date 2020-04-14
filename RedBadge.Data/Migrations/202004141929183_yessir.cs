namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yessir : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tattoo", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Tattoo", new[] { "ArtistID" });
            AddColumn("dbo.Artist", "ArtistFName", c => c.String(nullable: false));
            AddColumn("dbo.Artist", "ArtistLName", c => c.String(nullable: false));
            AddColumn("dbo.Client", "ClientFName", c => c.String(nullable: false));
            AddColumn("dbo.Client", "ClientLName", c => c.String(nullable: false));
            AlterColumn("dbo.Tattoo", "ArtistID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tattoo", "ArtistID");
            AddForeignKey("dbo.Tattoo", "ArtistID", "dbo.Artist", "ArtistID", cascadeDelete: true);
            DropColumn("dbo.Artist", "FName");
            DropColumn("dbo.Artist", "LName");
            DropColumn("dbo.Client", "FName");
            DropColumn("dbo.Client", "LName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "LName", c => c.String(nullable: false));
            AddColumn("dbo.Client", "FName", c => c.String(nullable: false));
            AddColumn("dbo.Artist", "LName", c => c.String(nullable: false));
            AddColumn("dbo.Artist", "FName", c => c.String(nullable: false));
            DropForeignKey("dbo.Tattoo", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Tattoo", new[] { "ArtistID" });
            AlterColumn("dbo.Tattoo", "ArtistID", c => c.Int());
            DropColumn("dbo.Client", "ClientLName");
            DropColumn("dbo.Client", "ClientFName");
            DropColumn("dbo.Artist", "ArtistLName");
            DropColumn("dbo.Artist", "ArtistFName");
            CreateIndex("dbo.Tattoo", "ArtistID");
            AddForeignKey("dbo.Tattoo", "ArtistID", "dbo.Artist", "ArtistID");
        }
    }
}
