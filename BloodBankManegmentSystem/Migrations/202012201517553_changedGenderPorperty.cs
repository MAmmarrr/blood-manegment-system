namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedGenderPorperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "gender", c => c.Int(nullable: false));
        }
    }
}
