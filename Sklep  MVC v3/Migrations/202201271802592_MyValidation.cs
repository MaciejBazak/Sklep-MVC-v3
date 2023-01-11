namespace Sklep__MVC_v3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
        }
    }
}
