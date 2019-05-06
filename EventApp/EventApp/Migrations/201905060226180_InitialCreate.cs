namespace EventApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventsID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 150),
                        StartDate = c.String(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        OrganizerName = c.String(nullable: false),
                        OrganizerContact = c.String(),
                        MaxTickets = c.Int(nullable: false),
                        AvailableTickets = c.Int(nullable: false),
                        Type_EventTypeID = c.Int(),
                    })
                .PrimaryKey(t => t.EventsID)
                .ForeignKey("dbo.EventTypes", t => t.Type_EventTypeID)
                .Index(t => t.Type_EventTypeID);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.EventTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Type_EventTypeID", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "Type_EventTypeID" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
