namespace Lab3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FK_DepartmentId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 12),
                        Salary = c.Double(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(maxLength: 256),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.FK_DepartmentId, cascadeDelete: true)
                .Index(t => t.FK_DepartmentId)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "FK_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Email" });
            DropIndex("dbo.Employees", new[] { "FK_DepartmentId" });
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
        }
    }
}
