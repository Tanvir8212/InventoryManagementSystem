namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemListAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Transaction_id", c => c.Int());
            CreateIndex("dbo.Items", "Transaction_id");
            AddForeignKey("dbo.Items", "Transaction_id", "dbo.Transactions", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Transaction_id", "dbo.Transactions");
            DropIndex("dbo.Items", new[] { "Transaction_id" });
            DropColumn("dbo.Items", "Transaction_id");
        }
    }
}
