namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        mobileNum = c.String(),
                        email = c.String(),
                        gender = c.String(),
                        age = c.Int(nullable: false),
                        address = c.String(),
                        Message = c.String(),
                        BloodTypeId = c.Byte(nullable: false),
                        BloodType_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BloodTypes", t => t.BloodType_id)
                .Index(t => t.BloodType_id);
            
            CreateTable(
                "dbo.BloodTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bloodGroup = c.String(),
                        creationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donors", "BloodType_id", "dbo.BloodTypes");
            DropIndex("dbo.Donors", new[] { "BloodType_id" });
            DropTable("dbo.BloodTypes");
            DropTable("dbo.Donors");
        }
    }
}
