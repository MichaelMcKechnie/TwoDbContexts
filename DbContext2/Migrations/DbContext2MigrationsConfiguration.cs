using System.Data.Entity.Migrations;
using TwoDbContexts.DbContext2.Db;

namespace TwoDbContexts.DbContext2.Migrations
{
    public class DbContext2MigrationsConfiguration : DbMigrationsConfiguration<DbContext2Database>
    {
        public DbContext2MigrationsConfiguration(): base()
        {
            ContextKey = "TwoDbContexts.DbContext2";
        }
    }
}
