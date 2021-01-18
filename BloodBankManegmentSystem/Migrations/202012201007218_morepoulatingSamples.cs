namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morepoulatingSamples : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (1,'A+')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (2,'A-')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (3,'B+')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (4,'B-')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (5,'O+')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (6,'O-')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (7,'AB+')");
            Sql("INSERT INTO BloodTypes (Id,bloodGroup) VALUES (8,'AB+')");
        }
        
        public override void Down()
        {
        }
    }
}
