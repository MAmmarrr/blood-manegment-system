namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genderId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donors", "GenderId", c => c.Byte(nullable: false));
            AddColumn("dbo.Donors", "gender_id", c => c.Int());
            CreateIndex("dbo.Donors", "gender_id");
            AddForeignKey("dbo.Donors", "gender_id", "dbo.Genders", "id");
            DropColumn("dbo.Donors", "gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donors", "gender", c => c.String());
            DropForeignKey("dbo.Donors", "gender_id", "dbo.Genders");
            DropIndex("dbo.Donors", new[] { "gender_id" });
            DropColumn("dbo.Donors", "gender_id");
            DropColumn("dbo.Donors", "GenderId");
        }
    }
}
