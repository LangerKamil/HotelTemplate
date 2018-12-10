namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingRoomStatusNavigationProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomStatus_Id", "dbo.RoomStatus");
            DropIndex("dbo.Rooms", new[] { "RoomStatus_Id" });
            RenameColumn(table: "dbo.Rooms", name: "RoomStatus_Id", newName: "RoomStatusId");
            AlterColumn("dbo.Rooms", "RoomStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Rooms", "RoomStatusId");
            AddForeignKey("dbo.Rooms", "RoomStatusId", "dbo.RoomStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomStatusId", "dbo.RoomStatus");
            DropIndex("dbo.Rooms", new[] { "RoomStatusId" });
            AlterColumn("dbo.Rooms", "RoomStatusId", c => c.Byte());
            RenameColumn(table: "dbo.Rooms", name: "RoomStatusId", newName: "RoomStatus_Id");
            CreateIndex("dbo.Rooms", "RoomStatus_Id");
            AddForeignKey("dbo.Rooms", "RoomStatus_Id", "dbo.RoomStatus", "Id");
        }
    }
}
