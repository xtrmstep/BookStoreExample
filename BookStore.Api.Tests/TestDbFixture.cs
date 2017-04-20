using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using BookStore.Data;
using BookStore.Data.Migrations;

namespace BookStore.Api.Tests
{
    public class TestDbFixture
    {
        public TestDbFixture()
        {
            // make sure DB is created and up-to-date
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());
            using (var ctx = new BookStoreContext())
            {
                // make a call to DB in order to migrate it to the latest version
                var r = ctx.Authors.Take(1).ToList();
            }
        }

        internal BookStoreContext CreateContext()
        {
            return new TestDbContext();
        }

        private class TestDbContext : BookStoreContext, IDisposable
        {
            private readonly TransactionScope _transaction;

            internal TestDbContext()
            {
                // create a transaction scope
                _transaction = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted });
            }

            public new void Dispose()
            {
                _transaction.Dispose();
            }
        }
    }
}