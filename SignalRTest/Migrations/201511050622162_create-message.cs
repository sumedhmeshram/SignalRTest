namespace SignalRTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createmessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageTest = c.String(),
                        UserId = c.Int(nullable: false),
                        IsSend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
