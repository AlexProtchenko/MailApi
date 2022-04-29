using System;
using System.Threading;
using MailApi.Data;
using MailApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MailApi.Tests;

public class DbFixture : IDisposable
{
    public DbFixture()
    {
        var builder = new DbContextOptionsBuilder();
        
        builder.UseSqlite("DataSource=:memory:", x => { });
        
        Db = new AppDbContent(builder.Options);
        Db.Database.OpenConnectionAsync();
        Db.Database.EnsureCreatedAsync();
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public AppDbContent Db { get; private set; }
}