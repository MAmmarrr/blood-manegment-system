namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateTimeField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "donationTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "donationTime", c => c.DateTime(nullable: false));
        }
    }
}
