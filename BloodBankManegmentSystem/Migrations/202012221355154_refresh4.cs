namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refresh4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "donationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "donationTime", c => c.DateTime(nullable: false));
        }
    }
}
