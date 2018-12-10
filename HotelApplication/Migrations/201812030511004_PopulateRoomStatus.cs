namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoomStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RoomStatus(Id,Name) VALUES (1,'Available')");
            Sql("INSERT INTO RoomStatus(Id,Name) VALUES (2,'Reserved')");
            Sql("INSERT INTO RoomStatus(Id,Name) VALUES (3,'Occupied')");
        }
        
        public override void Down()
        {
        }
    }
}
