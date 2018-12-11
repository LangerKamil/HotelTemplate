namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRooms : DbMigration
    {
        public override void Up()
        {
            // SMALL ROOMS
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(2,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(3,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(4,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(5,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(6,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(7,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(8,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(9,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(10,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(11,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(12,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(13,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(14,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(15,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(16,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(17,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(18,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(19,'1999.1.1','1999.1.1',1,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(20,'1999.1.1','1999.1.1',1,2)");

            // MEDIUM ROOMS
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(21,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(22,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(23,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(24,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(25,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(26,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(27,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(28,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(29,'1999.1.1','1999.1.1',2,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(30,'1999.1.1','1999.1.1',2,2)");

            // LARGE ROOMS
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(31,'1999.1.1','1999.1.1',3,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(32,'1999.1.1','1999.1.1',3,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(33,'1999.1.1','1999.1.1',3,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(34,'1999.1.1','1999.1.1',3,2)");
            Sql("INSERT INTO Rooms(Id,CheckIn,CheckOut,RoomTypeId,RoomStatusId) VALUES(35,'1999.1.1','1999.1.1',3,2)");



        }

        public override void Down()
        {
        }
    }
}
