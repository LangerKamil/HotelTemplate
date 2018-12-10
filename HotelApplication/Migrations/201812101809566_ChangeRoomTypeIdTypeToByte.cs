namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoomTypeIdTypeToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomType_Id" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId_Id" });
            RenameColumn(table: "dbo.Rooms", name: "RoomType_Id", newName: "RoomTypeId");
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Rooms", "RoomTypeId");
            AddForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "RoomTypeId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomTypeId_Id", c => c.Byte());
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            AlterColumn("dbo.Rooms", "RoomTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Rooms", name: "RoomTypeId", newName: "RoomType_Id");
            CreateIndex("dbo.Rooms", "RoomTypeId_Id");
            CreateIndex("dbo.Rooms", "RoomType_Id");
            AddForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes", "Id");
            AddForeignKey("dbo.Rooms", "RoomTypeId_Id", "dbo.RoomTypes", "Id");
        }
    }
}
