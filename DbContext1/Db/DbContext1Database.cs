using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TwoDbContexts.DbContext1.Domain;

namespace TwoDbContexts.DbContext1.Db
{
    public class DbContext1Database: DbContext
    {
        public DbContext1Database() : this("LocalDatabase")
        {
        }

        public DbContext1Database(string connectionString) : base("name=" + connectionString)
        {
        }

        public DbSet<DbContext1Domain> DbContext1Domain { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
