using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LiteDB;
using TestApp.Interfaces;
using TestApp.Models;

namespace TestApp.Data
{
    public class TestAppContext : DbContext, ITestAppContext
    {
        public DbSet<Contractor> Contractors { get; set; }

        public LiteDatabase Database { get; }

        public string ApiKey { get; }

        public TestAppContext(IOptions<ApiAndDBOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);
            ApiKey = options.Value.ApiKey;
        }
    }
}
