namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedReservationStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ReservationStatus(Id,Name) VALUES(1,'Accepted')");
            Sql("INSERT INTO ReservationStatus(Id,Name) VALUES(2,'Canceled')");
            Sql("INSERT INTO ReservationStatus(Id,Name) VALUES(3,'Pending')");
        }
        
        public override void Down()
        {
        }
    }
}
