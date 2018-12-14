namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckInAndCheckOutToReservations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "CheckIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "CheckOut", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "CheckOut");
            DropColumn("dbo.Reservations", "CheckIn");
        }
    }
}
