namespace ContactManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateofBirth = c.DateTime(nullable: false),
                        Married = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
