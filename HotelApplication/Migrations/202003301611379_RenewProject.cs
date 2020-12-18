namespace HotelApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenewProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "CheckIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "CheckOut", c => c.DateTime(nullable: false));
            AddColumn("dbo.RoomTypes", "AvailableAmount", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "AvailableAmount");
            DropColumn("dbo.Rooms", "CheckOut");
            DropColumn("dbo.Rooms", "CheckIn");
        }
    }
}
