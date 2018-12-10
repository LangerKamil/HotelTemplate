namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRoomTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RoomTypes(Id,Name,Price,Size,TotalAmount,AvailableAmount) VALUES (1,'Small',200,'2 Persons',20,20)");
            Sql("INSERT INTO RoomTypes(Id,Name,Price,Size,TotalAmount,AvailableAmount) VALUES (2,'Medium',300,'3 Persons',10,10)");
            Sql("INSERT INTO RoomTypes(Id,Name,Price,Size,TotalAmount,AvailableAmount) VALUES (3,'Large',450,'4-5 Persons',5,5)");
        }
        
        public override void Down()
        {
        }
    }
}
