namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class designedDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        totalPurchase = c.Int(nullable: false),
                        email = c.String(),
                        customerType_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CustomerTypes", t => t.customerType_id)
                .Index(t => t.customerType_id);
            
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        discountRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        sellingPrice = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        productType_id = c.Int(),
                        supplier_id = c.Int(),
                        Transaction_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ProductTypes", t => t.productType_id)
                .ForeignKey("dbo.Suppliers", t => t.supplier_id)
                .ForeignKey("dbo.Transactions", t => t.Transaction_id)
                .Index(t => t.productType_id)
                .Index(t => t.supplier_id)
                .Index(t => t.Transaction_id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        phone = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PurchaseLots",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        buyingPrice = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                        dateTime = c.DateTime(nullable: false),
                        product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Transaction_id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PurchaseLots", "product_id", "dbo.Products");
            DropForeignKey("dbo.Products", "supplier_id", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "productType_id", "dbo.ProductTypes");
            DropForeignKey("dbo.Customers", "customerType_id", "dbo.CustomerTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Transactions", new[] { "customer_id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PurchaseLots", new[] { "product_id" });
            DropIndex("dbo.Products", new[] { "Transaction_id" });
            DropIndex("dbo.Products", new[] { "supplier_id" });
            DropIndex("dbo.Products", new[] { "productType_id" });
            DropIndex("dbo.Customers", new[] { "customerType_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Transactions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseLots");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.Customers");
        }
    }
}
