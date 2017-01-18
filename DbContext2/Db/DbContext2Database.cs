using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TwoDbContexts.DbContext2.Domain;

namespace TwoDbContexts.DbContext2.Db
{
    public class DbContext2Database: DbContext
    {
        public DbContext2Database() : this("LocalDatabase")
        {
        }

        public DbContext2Database(string connectionString) : base("name=" + connectionString)
        {
        }

        public DbSet<DbContext2Domain> DbContext2Domain { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
