namespace TaskProoject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdateusernamenpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "UserName", c => c.String(maxLength: 50));
            AddColumn("dbo.Memberships", "Password", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Password");
            DropColumn("dbo.Memberships", "UserName");
        }
    }
}
