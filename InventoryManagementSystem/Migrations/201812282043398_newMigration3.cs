namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Products", "Transaction_id", "dbo.Transactions");
            DropIndex("dbo.Products", new[] { "Transaction_id" });
            DropIndex("dbo.Transactions", new[] { "customer_id" });
            DropColumn("dbo.Products", "Transaction_id");
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        totalPrice = c.Double(nullable: false),
                        profit = c.Double(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Products", "Transaction_id", c => c.Int());
            CreateIndex("dbo.Transactions", "customer_id");
            CreateIndex("dbo.Products", "Transaction_id");
            AddForeignKey("dbo.Products", "Transaction_id", "dbo.Transactions", "id");
            AddForeignKey("dbo.Transactions", "customer_id", "dbo.Customers", "id");
        }
    }
}
