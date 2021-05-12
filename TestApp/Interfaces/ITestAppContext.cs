using Microsoft.EntityFrameworkCore;
using LiteDB;
using TestApp.Models;

namespace TestApp.Interfaces
{
    public interface ITestAppContext
    {
        DbSet<Contractor> Contractors { get; set; }
        LiteDatabase Database { get; }
        string ApiKey { get; }
    }
}