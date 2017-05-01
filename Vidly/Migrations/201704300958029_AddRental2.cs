namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Movies", new[] { "Rental_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Rental_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Rental_Id", c => c.Int());
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int());
            DropColumn("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Movies", "Rental_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Movies", "Rental_Id", "dbo.Rentals", "Id");
        }
    }
}
