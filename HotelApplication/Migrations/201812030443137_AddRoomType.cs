namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false),
                        Size = c.String(),
                        TotalAmount = c.Byte(nullable: false),
                        AvailableAmount = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rooms", "RoomType_Id", c => c.Byte());
            AddColumn("dbo.Rooms", "RoomTypeId_Id", c => c.Byte());
            CreateIndex("dbo.Rooms", "RoomType_Id");
            CreateIndex("dbo.Rooms", "RoomTypeId_Id");
            AddForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes", "Id");
            AddForeignKey("dbo.Rooms", "RoomTypeId_Id", "dbo.RoomTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "RoomType_Id", "dbo.RoomTypes");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId_Id" });
            DropIndex("dbo.Rooms", new[] { "RoomType_Id" });
            DropColumn("dbo.Rooms", "RoomTypeId_Id");
            DropColumn("dbo.Rooms", "RoomType_Id");
            DropTable("dbo.RoomTypes");
        }
    }
}
