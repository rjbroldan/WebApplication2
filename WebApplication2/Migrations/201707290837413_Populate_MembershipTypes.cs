namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate_MembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 'Pay As You Go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, '1 Month', 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, '3 Months', 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, '6 Months', 144, 6, 20)");
            Sql("INSERT INTO MembershipTypes (Id, MembershipTypeName, SignUpFee, DurationInMonths, DiscountRate) VALUES (5, '12 Months', 277, 12, 30)");
        }
        
        public override void Down()
        {
        }
    }
}
