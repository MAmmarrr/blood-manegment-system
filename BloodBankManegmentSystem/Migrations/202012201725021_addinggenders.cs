namespace BloodBankManegmentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinggenders : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENDERS (gender) VALUES ('Male')");
            Sql("INSERT INTO GENDERS (gender) VALUES ('Female')");
        }
        
        public override void Down()
        {
        }
    }
}
