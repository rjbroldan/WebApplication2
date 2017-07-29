namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovieGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Action')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Animation')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Drama')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Fantasy')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Fiction')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Philisophical')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Political')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO MovieGenres (Name) VALUES ('Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
