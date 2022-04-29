using System;
using System.Threading.Tasks;
using MailApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MailApi.Tests;

public abstract class TestBase
{
    public async Task<AppDbContent> GetDbContext()
    {
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        
        builder.UseSqlite("DataSource=:memory:", x => { });
        
        var dbContext = new AppDbContent(builder.Options);

        await dbContext.Database.OpenConnectionAsync();
        
        await dbContext.Database.EnsureCreatedAsync();

        return dbContext;
    }
    
}

