namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refresh1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Donors", new[] { "gender_id" });
            CreateIndex("dbo.Donors", "Gender_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Donors", new[] { "Gender_id" });
            CreateIndex("dbo.Donors", "gender_id");
        }
    }
}
