namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "mobileNum", c => c.String(nullable: false));
            AlterColumn("dbo.Donors", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "email", c => c.String());
            AlterColumn("dbo.Donors", "mobileNum", c => c.String());
        }
    }
}
