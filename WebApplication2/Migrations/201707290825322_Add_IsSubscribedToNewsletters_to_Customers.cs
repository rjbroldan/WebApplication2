namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsSubscribedToNewsletters_to_Customers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewletters", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MembershipType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MembershipType");
            DropColumn("dbo.Customers", "IsSubscribedToNewletters");
        }
    }
}
