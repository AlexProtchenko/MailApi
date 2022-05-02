using System;
using System.Collections.Generic;
using MailApi.Data;
using MailApi.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace MailApi.Tests;

public class DbFixture : IDisposable
{
    private readonly AppDbContent _db;
    public DbFixture()
    {
        var builder = new DbContextOptionsBuilder();
        
        builder.UseSqlite("DataSource=:memory:", x => { });
        
        _db = new AppDbContent(builder.Options);
        _db.Database.OpenConnectionAsync();
        _db.Database.EnsureCreatedAsync();
        var a = new GetContentRepository(_db);
        var b = new ContentRepository(_db);
        var people = new List<dynamic> { a, b};
        Repo = people;
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    public List<dynamic> Repo { get; private set; }
}