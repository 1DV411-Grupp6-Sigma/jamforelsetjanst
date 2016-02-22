namespace TownComparisons.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryChanges : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CategoryOrganisationalUnit", new[] { "Category_Id" });
            AddColumn("dbo.OrganisationalUnitInfo", "Name", c => c.String());
            AddColumn("dbo.OrganisationalUnitInfo", "Category_Id", c => c.Int());
            CreateIndex("dbo.OrganisationalUnitInfo", "Category_Id");
            DropTable("dbo.CategoryOrganisationalUnit");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryOrganisationalUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WebServiceName = c.String(),
                        OrganisationalUnitId = c.String(),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.OrganisationalUnitInfo", new[] { "Category_Id" });
            DropColumn("dbo.OrganisationalUnitInfo", "Category_Id");
            DropColumn("dbo.OrganisationalUnitInfo", "Name");
            CreateIndex("dbo.CategoryOrganisationalUnit", "Category_Id");
        }
    }
}
