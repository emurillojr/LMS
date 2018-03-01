namespace Tyler_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ImageName = c.String(),
                        Type = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.RatingId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(nullable: false),
                        RatingDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieShows", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.MovieShows", "CompanyId", "dbo.Companies");
            DropIndex("dbo.MovieShows", new[] { "RatingId" });
            DropIndex("dbo.MovieShows", new[] { "CompanyId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Companies");
            DropTable("dbo.MovieShows");
        }
    }
}
