namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acceptor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acceptors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        mobileNum = c.String(nullable: false),
                        email = c.String(nullable: false),
                        GenderId = c.Byte(nullable: false),
                        age = c.Int(nullable: false),
                        address = c.String(),
                        BloodTypeId = c.Byte(nullable: false),
                        BloodType_id = c.Int(),
                        Gender_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BloodTypes", t => t.BloodType_id)
                .ForeignKey("dbo.Genders", t => t.Gender_id)
                .Index(t => t.BloodType_id)
                .Index(t => t.Gender_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Acceptors", "Gender_id", "dbo.Genders");
            DropForeignKey("dbo.Acceptors", "BloodType_id", "dbo.BloodTypes");
            DropIndex("dbo.Acceptors", new[] { "Gender_id" });
            DropIndex("dbo.Acceptors", new[] { "BloodType_id" });
            DropTable("dbo.Acceptors");
        }
    }
}
