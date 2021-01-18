namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refresh3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "donationTime", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "donationTime", c => c.String());
        }
    }
}
