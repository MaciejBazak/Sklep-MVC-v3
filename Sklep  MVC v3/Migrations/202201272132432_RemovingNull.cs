namespace Sklep__MVC_v3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Active", c => c.Boolean());
        }
    }
}
