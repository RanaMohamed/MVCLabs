namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueemail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Employees", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Email" });
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false));
        }
    }
}
