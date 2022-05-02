using System;
using System.Collections.Generic;
using MailApi.Data;
using MailApi.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace MailApi.Tests;

public class DbFixture : IDisposable
{
    public DbFixture()
    {
        var builder = new DbContextOptionsBuilder();
        
        builder.UseSqlite("DataSource=:memory:", x => { });
        
        var content = new AppDbContent(builder.Options);
        content.Database.OpenConnectionAsync();
        content.Database.EnsureCreatedAsync();
        var a = new GetContentRepository(content);
        var b = new ContentRepository(content);
        List<dynamic> people = new List<dynamic> { a, b};
        Repo = people;
    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
    }

    public List<dynamic> Repo { get; private set; }
}