namespace TwoDbContexts.DbContext2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbContext2Domain",
                c => new
                    {
                        SomeNumber = c.Int(nullable: false, identity: true),
                        SomeString = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SomeNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbContext2Domain");
        }
    }
}
