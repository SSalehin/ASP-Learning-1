namespace Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReaddingPosts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "TopicId" });
            AddColumn("dbo.Posts", "UserEmail", c => c.String());
            AddColumn("dbo.Posts", "UserName", c => c.String());
            AddColumn("dbo.Posts", "PostedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "CreationTime");
            DropColumn("dbo.Posts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "CreationTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Posts", "PostedOn");
            DropColumn("dbo.Posts", "UserName");
            DropColumn("dbo.Posts", "UserEmail");
            CreateIndex("dbo.Posts", "TopicId");
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
    }
}
