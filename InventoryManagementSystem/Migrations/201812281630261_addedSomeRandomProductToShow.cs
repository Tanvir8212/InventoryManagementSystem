namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSomeRandomProductToShow : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Products] ( [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES ( N'Meril Soap', 25, 5, 5, NULL, NULL)
INSERT INTO [dbo].[Products] ( [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES ( N'Lux', 25, 6, 5, NULL, NULL)
INSERT INTO [dbo].[Products] ( [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES ( N'Dove', 35, 100, 5, NULL, NULL)
INSERT INTO [dbo].[Products] ( [name], [sellingPrice], [quantity], [productType_id], [supplier_id], [Transaction_id]) VALUES ( N'Cadberry', 100, 7, 7, NULL, NULL)");
        }
        
        public override void Down()
        {
        }
    }
}
