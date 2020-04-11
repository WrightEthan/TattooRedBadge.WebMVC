namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class almostdone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artist");
        }
    }
}
