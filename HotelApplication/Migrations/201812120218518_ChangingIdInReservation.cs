namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingIdInReservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.Genders", new[] { "Reservation_Id" });
            DropIndex("dbo.RoomTypes", new[] { "Reservation_Id" });
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.Genders", "Reservation_Id", c => c.Byte());
            AlterColumn("dbo.Reservations", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.RoomTypes", "Reservation_Id", c => c.Byte());
            AddPrimaryKey("dbo.Reservations", "Id");
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
            DropPrimaryKey("dbo.Reservations");
            AlterColumn("dbo.RoomTypes", "Reservation_Id", c => c.Int());
            AlterColumn("dbo.Reservations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Genders", "Reservation_Id", c => c.Int());
            AddPrimaryKey("dbo.Reservations", "Id");
            CreateIndex("dbo.RoomTypes", "Reservation_Id");
            CreateIndex("dbo.Genders", "Reservation_Id");
            AddForeignKey("dbo.RoomTypes", "Reservation_Id", "dbo.Reservations", "Id");
            AddForeignKey("dbo.Genders", "Reservation_Id", "dbo.Reservations", "Id");
        }
    }
}
