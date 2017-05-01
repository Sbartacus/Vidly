namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'319381c3-0c81-4b24-a570-f930b951a691', N'admin@fai.com', 0, N'AN5KxD+m9NH49aXo6HyhiuKAzckw3yuDJp7HYBfFHCxr8NOtiFRvb4O/k3ytrc+ghA==', N'73cfd437-1fb5-456a-a32e-916fa7499595', NULL, 0, 0, NULL, 1, 0, N'admin@fai.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e2abf8b4-c2a4-4d66-ab4c-7e0b57a98c91', N'guest@fai.com', 0, N'AFFEwhNctZdDdXyqaSX1dhW5F/D7140zNlIdxvcDai/KL6E2Bdk6LW0m47PwCHw91g==', N'78efabd1-678e-4592-a4e7-3713c7960eac', NULL, 0, 0, NULL, 1, 0, N'guest@fai.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'287b4be6-fd59-4823-b4f3-7db9374733a4', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'319381c3-0c81-4b24-a570-f930b951a691', N'287b4be6-fd59-4823-b4f3-7db9374733a4')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2abf8b4-c2a4-4d66-ab4c-7e0b57a98c91', N'287b4be6-fd59-4823-b4f3-7db9374733a4')

                            
                ");
        }
        
        public override void Down()
        {
        }
    }
}
