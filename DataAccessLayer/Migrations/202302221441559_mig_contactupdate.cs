namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Subject", c => c.String(maxLength: 50));
            DropColumn("dbo.Contacts", "Sunject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Sunject", c => c.String(maxLength: 50));
            DropColumn("dbo.Contacts", "Subject");
        }
    }
}
