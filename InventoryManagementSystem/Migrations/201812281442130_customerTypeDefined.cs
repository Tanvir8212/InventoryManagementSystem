namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerTypeDefined : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[CustomerTypes] ( [name], [discountRate]) VALUES ( N'Normal Customer', 0)
                INSERT INTO [dbo].[CustomerTypes] ( [name], [discountRate]) VALUES ( N'Regular Customer', 3)
                INSERT INTO [dbo].[CustomerTypes] ( [name], [discountRate]) VALUES ( N'Special Customer', 5)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
