namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2b6a7810-733d-42f9-b118-40336c61756a', N'tanvir8212@admin.com', 0, N'AJdJhvdoBSrXWGPQO9hiAF4A446Sx/BrC5c0K0vwu5nwFJ3QiUH7IGOoaa5+CHFyXA==', N'f6adbf79-8734-4202-be13-d49b61f86a8e', NULL, 0, 0, NULL, 1, 0, N'tanvir8212@admin.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cbd869f7-2c55-493c-bd52-f09d5c4a10b4', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2b6a7810-733d-42f9-b118-40336c61756a', N'cbd869f7-2c55-493c-bd52-f09d5c4a10b4')

");
        }
        
        public override void Down()
        {
        }
    }
}
