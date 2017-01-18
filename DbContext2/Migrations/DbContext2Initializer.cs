using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics.Contracts;
using System.Linq;
using TwoDbContexts.DbContext2.Db;

namespace TwoDbContexts.DbContext2.Migrations
{
    /// <summary>
    /// Connect to a DB server and either create the desired database (if it doesn't exist)
    /// or upgrade it to the latest version (if needed). 
    /// 
    /// Class based on http://stackoverflow.com/questions/15796115/how-to-create-initializer-to-create-and-migrate-mysql-database
    /// </summary>
    public class DbContext2Initializer : IDatabaseInitializer<DbContext2Database>
    {
        private readonly string _connection;

        public DbContext2Initializer(string connection)
        {
            Contract.Requires(!string.IsNullOrEmpty(connection), "connection");
            _connection = connection;
        }

        public void InitializeDatabase(DbContext2Database context)
        {
            Contract.Requires(context != null, "context");

            var configuration = new DbContext2MigrationsConfiguration()
            {
                TargetDatabase = new DbConnectionInfo(_connection)
            };

            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(throwIfNoMetadata: false))
            {
                var migrator = new DbMigrator(configuration);
                string[] pastMigrations = migrator.GetDatabaseMigrations().OrderBy(s => s).ToArray();
                string[] knownMigrations = migrator.GetLocalMigrations().OrderBy(s => s).ToArray();
                string[] pendingMigrations = migrator.GetPendingMigrations().OrderBy(s => s).ToArray();
                Console.Out.WriteLine("Known migrations:");
                foreach (var m in knownMigrations)
                    Console.Out.WriteLine(m);
                Console.Out.WriteLine("Past migrations:");
                foreach (var m in pastMigrations)
                    Console.Out.WriteLine(m);
                Console.Out.WriteLine("Pending migrations:");
                foreach (var m in pendingMigrations)
                    Console.Out.WriteLine(m);

                if (!pendingMigrations.Any())
                    Console.Out.WriteLine($"Database mismatch: exists={context.Database.Exists()} and compatibility={context.Database.CompatibleWithModel(throwIfNoMetadata: false)} but there are no migrations pending.");

                foreach (string s in migrator.GetPendingMigrations())
                {
                    Console.Out.WriteLine($"Applying database migration {s}.");
                    migrator.Update(s);
                }
            }

            context.SaveChanges();
        }


    }
}
