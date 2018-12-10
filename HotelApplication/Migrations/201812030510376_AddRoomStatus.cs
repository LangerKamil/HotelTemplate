namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "RoomStatus_Id", c => c.Byte());
            CreateIndex("dbo.Rooms", "RoomStatus_Id");
            AddForeignKey("dbo.Rooms", "RoomStatus_Id", "dbo.RoomStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomStatus_Id", "dbo.RoomStatus");
            DropIndex("dbo.Rooms", new[] { "RoomStatus_Id" });
            DropColumn("dbo.Rooms", "RoomStatus_Id");
            DropTable("dbo.RoomStatus");
        }
    }
}
