namespace Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTopics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Topics(Name) VALUES('Miscellaneous')");
            Sql("INSERT INTO Topics(Name) VALUES('Astronomy')");
            Sql("INSERT INTO Topics(Name) VALUES('Games')");
            Sql("INSERT INTO Topics(Name) VALUES('Physics')");
            Sql("INSERT INTO Topics(Name) VALUES('Math')");
            Sql("INSERT INTO Topics(Name) VALUES('Computer Science')");
            Sql("INSERT INTO Topics(Name) VALUES('Anthropology')");
            Sql("INSERT INTO Topics(Name) VALUES('Literature')");

        }
        
        public override void Down()
        {
            DropTable("dbo.Topics");
        }
    }
}
