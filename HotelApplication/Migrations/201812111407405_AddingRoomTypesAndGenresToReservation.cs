namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRoomTypesAndGenresToReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genders", "Reservation_Id", c => c.Int());
            AddColumn("dbo.RoomTypes", "Reservation_Id", c => c.Int());
            CreateIndex("dbo.Genders", "Reservation_Id");
            CreateIndex("dbo.RoomTypes", "Reservation_Id");
            AddForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations", "Id");
            AddForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.RoomTypes", new[] { "Reservation_Id" });
            DropIndex("dbo.Genders", new[] { "Reservation_Id" });
            DropColumn("dbo.RoomTypes", "Reservation_Id");
            DropColumn("dbo.Genders", "Reservation_Id");
        }
    }
}
