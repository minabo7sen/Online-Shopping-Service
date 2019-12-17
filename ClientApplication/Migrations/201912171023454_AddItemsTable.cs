namespace ClientApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ItemId })
                .ForeignKey("dbo.ShoppingItems", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartItems", "ItemId", "dbo.ShoppingItems");
            DropIndex("dbo.CartItems", new[] { "ItemId" });
            DropIndex("dbo.CartItems", new[] { "UserId" });
            DropTable("dbo.CartItems");
            DropTable("dbo.ShoppingItems");
        }
    }
}
