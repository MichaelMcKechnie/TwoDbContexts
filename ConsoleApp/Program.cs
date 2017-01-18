using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using SupplierReporting.AppServerUtilities.Db;
using TwoDbContexts.DbContext1.Db;
using TwoDbContexts.DbContext1.Domain;
using TwoDbContexts.DbContext2.Db;
using TwoDbContexts.DbContext2.Domain;
using TwoDbContexts.DbContext2.Migrations;

namespace ConsoleApp
{
    public class Program
    {
        private const string Connection = "LocalDatabase";

        private static void Main(string[] args)
        {
            File.Delete("localDatabase.sdf");

            bool coinToss = new Random().Next() % 2 == 1; // order is irrelevant - whichever is second will fail

            if (coinToss)
            {
                EnsureDatabase1();
                EnsureDatabase2();
            }
            else
            {
                EnsureDatabase2();
                EnsureDatabase1();
            }

            Console.ReadLine();
        }

        private static void EnsureDatabase2()
        {
            var initializer2 = new DbContext2Initializer(Connection);
            Database.SetInitializer(initializer2);
            using (var db = new DbContext2Database(Connection))
            {
                if (!db.DbContext2Domain.Any())
                {
                    db.DbContext2Domain.Add(new DbContext2Domain {SomeNumber = 1, SomeString = "One"});
                    db.SaveChanges();
                }
                Console.Out.WriteLine($"DbContext2.DbContext2Domain has {db.DbContext2Domain.Count()} rows.");
            }
        }

        private static void EnsureDatabase1()
        {
            var initializer1 = new DbContext1Initializer(Connection);
            Database.SetInitializer(initializer1);
            using (var db = new DbContext1Database(Connection))
            {
                if (!db.DbContext1Domain.Any())
                {
                    db.DbContext1Domain.Add(new DbContext1Domain {SomeNumber = 1, SomeString = "One"});
                    db.SaveChanges();
                }
                Console.Out.WriteLine($"DbContext1.DbContext1Domain has {db.DbContext1Domain.Count()} rows.");
            }
        }
    }
}
