namespace Cloud_Property.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GL_COSTPOOL", "PROJECTFY", c => c.String());
            AddColumn("dbo.GL_COSTPOOL", "LOCATION", c => c.String());
            AddColumn("dbo.GL_COSTPOOL", "PCITY", c => c.String());
            AddColumn("dbo.GL_COSTPOOL", "PSIZE", c => c.String());
            AddColumn("dbo.GL_COSTPOOL", "PTYPE", c => c.String());
            AddColumn("dbo.GL_COSTPOOL", "EHODT", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GL_COSTPOOL", "EHODT");
            DropColumn("dbo.GL_COSTPOOL", "PTYPE");
            DropColumn("dbo.GL_COSTPOOL", "PSIZE");
            DropColumn("dbo.GL_COSTPOOL", "PCITY");
            DropColumn("dbo.GL_COSTPOOL", "LOCATION");
            DropColumn("dbo.GL_COSTPOOL", "PROJECTFY");
        }
    }
}
