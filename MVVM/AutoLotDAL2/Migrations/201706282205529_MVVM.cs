namespace AutoLotDAL2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MVVM : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
