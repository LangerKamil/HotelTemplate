namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRStatusIdToReservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "RStatus_Id", "dbo.ReservationStatus");
            DropIndex("dbo.Reservations", new[] { "RStatus_Id" });
            RenameColumn(table: "dbo.Reservations", name: "RStatus_Id", newName: "RStatusId");
            AlterColumn("dbo.Reservations", "RStatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Reservations", "RStatusId");
            AddForeignKey("dbo.Reservations", "RStatusId", "dbo.ReservationStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "RStatusId", "dbo.ReservationStatus");
            DropIndex("dbo.Reservations", new[] { "RStatusId" });
            AlterColumn("dbo.Reservations", "RStatusId", c => c.Byte());
            RenameColumn(table: "dbo.Reservations", name: "RStatusId", newName: "RStatus_Id");
            CreateIndex("dbo.Reservations", "RStatus_Id");
            AddForeignKey("dbo.Reservations", "RStatus_Id", "dbo.ReservationStatus", "Id");
        }
    }
}
