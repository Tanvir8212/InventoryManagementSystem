namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProductType : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[ProductTypes] ( [Name]) VALUES (N'Soap')
            INSERT INTO [dbo].[ProductTypes] ( [Name]) VALUES ( N'Chips')
            INSERT INTO [dbo].[ProductTypes] ( [Name]) VALUES ( N'Chocolate')
            INSERT INTO [dbo].[ProductTypes] ( [Name]) VALUES ( N'Ice Creame')
");
        }
        
        public override void Down()
        {
        }
    }
}
