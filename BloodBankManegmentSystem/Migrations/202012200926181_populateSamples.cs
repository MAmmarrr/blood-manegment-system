namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateSamples : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BloodTypes", "bloodGroup", c => c.String(nullable: false, maxLength: 255));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BloodTypes", "bloodGroup", c => c.String());
        }
    }
}
