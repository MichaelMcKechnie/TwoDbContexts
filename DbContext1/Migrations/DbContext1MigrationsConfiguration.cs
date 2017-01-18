using System.Data.Entity.Migrations;
using TwoDbContexts.DbContext1.Db;

namespace TwoDbContexts.DbContext1.Migrations
{
    public class DbContext1MigrationsConfiguration : DbMigrationsConfiguration<DbContext1Database>
    {
        public DbContext1MigrationsConfiguration(): base()
        {
            ContextKey = "TwoDbContexts.DbContext1";
        }
    }
}
