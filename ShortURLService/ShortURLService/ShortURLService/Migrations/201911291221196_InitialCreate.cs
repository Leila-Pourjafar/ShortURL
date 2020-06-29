namespace ShortURLService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.URLs",
                c => new
                    {
                        UrlId = c.Int(nullable: false, identity: true),
                        LongUrl = c.String(nullable: false),
                        ShortUrl = c.String(nullable: false),
                        Hits = c.Int(nullable: false),
                        GeneratedDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.UrlId);
            
            CreateTable(
                "dbo.UrlStats",
                c => new
                    {
                        UrlStatId = c.Int(nullable: false, identity: true),
                        UserAgent = c.String(),
                        UserHostAddress = c.String(),
                        UserLanguage = c.String(),
                        UrlRefferer = c.String(),
                        IsMobile = c.Boolean(nullable: false),
                        Browser = c.String(),
                        MajorVersion = c.Int(nullable: false),
                        UrlId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UrlStatId)
                .ForeignKey("dbo.URLs", t => t.UrlId, cascadeDelete: true)
                .Index(t => t.UrlId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UrlStats", "UrlId", "dbo.URLs");
            DropIndex("dbo.UrlStats", new[] { "UrlId" });
            DropTable("dbo.UrlStats");
            DropTable("dbo.URLs");
        }
    }
}
