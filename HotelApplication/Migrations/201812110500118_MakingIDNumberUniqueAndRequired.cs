namespace HotelApplication.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class MakingIDNumberUniqueAndRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IDNumber", c => c.String(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "IDNumber",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IDNumber, IsUnique: True }")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IDNumber", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "IDNumber",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IDNumber, IsUnique: Fasle }", newValue: null)
                    },
                }));
        }
    }
}
