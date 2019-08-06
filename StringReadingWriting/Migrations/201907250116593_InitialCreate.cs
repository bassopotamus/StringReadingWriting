namespace StringReadingWriting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        Index = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        NewPass = c.String(),
                    })
                .PrimaryKey(t => t.Index);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Passwords");
        }
    }
}
