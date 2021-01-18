namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingCreationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "donationTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Donors", "name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.BloodTypes", "creationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BloodTypes", "creationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Donors", "name", c => c.String());
            DropColumn("dbo.Donors", "donationTime");
        }
    }
}
