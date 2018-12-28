namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionTableDone : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customer_id)
                .Index(t => t.customer_id);
            
            AddColumn("dbo.Items", "Transaction_id", c => c.Int());
            CreateIndex("dbo.Items", "Transaction_id");
            AddForeignKey("dbo.Items", "Transaction_id", "dbo.Transactions", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Transaction_id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "customer_id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "customer_id" });
            DropIndex("dbo.Items", new[] { "Transaction_id" });
            DropColumn("dbo.Items", "Transaction_id");
            DropTable("dbo.Transactions");
        }
    }
}
