namespace Real_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInventoryModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Inventories", newName: "Inventory");
            DropPrimaryKey("dbo.Inventory");
            AddColumn("dbo.Inventory", "ItemID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Inventory", "ItemName", c => c.String());
            AddPrimaryKey("dbo.Inventory", "ItemID");
            DropColumn("dbo.Inventory", "Id");
            DropColumn("dbo.Inventory", "Name");
            DropColumn("dbo.Inventory", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventory", "Description", c => c.String());
            AddColumn("dbo.Inventory", "Name", c => c.String());
            AddColumn("dbo.Inventory", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Inventory");
            DropColumn("dbo.Inventory", "ItemName");
            DropColumn("dbo.Inventory", "ItemID");
            AddPrimaryKey("dbo.Inventory", "Id");
            RenameTable(name: "dbo.Inventory", newName: "Inventories");
        }
    }
}
