namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            RenameColumn(table: "dbo.Rentals", name: "CustomerId", newName: "Customer_Id");
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTimeOffset(precision: 7));
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AlterColumn("dbo.Rentals", "DateReturned", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerId");
            CreateIndex("dbo.Rentals", "CustomerId");
            AddForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
