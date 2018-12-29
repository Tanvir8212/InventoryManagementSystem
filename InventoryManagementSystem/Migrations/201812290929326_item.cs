namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class item : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Transaction_id", "dbo.Transactions");
            DropIndex("dbo.Items", new[] { "Transaction_id" });
            DropColumn("dbo.Items", "Transaction_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Transaction_id", c => c.Int());
            CreateIndex("dbo.Items", "Transaction_id");
            AddForeignKey("dbo.Items", "Transaction_id", "dbo.Transactions", "id");
        }
    }
}
