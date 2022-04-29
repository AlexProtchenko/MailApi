using System;
using System.Linq;
using System.Threading.Tasks;
using MailApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MailApi.Tests;

public class DbContentTests : IClassFixture<DbFixture>
{
    private readonly DbFixture _fixture;

    public DbContentTests(DbFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact, Order(1)]
    public async Task AddDepartmentTest()
    {
        // Prepare
        _fixture.Db.Departments.Add(new Department
        {
            Name = "Development",
        });
        await _fixture.Db.SaveChangesAsync();

        // Execute
        var data = _fixture.Db.Departments.ToList();

        // Assert
        Assert.Single(data);
        Assert.Contains(data, d => d.DepartmentId == 1);
        Assert.Contains(data, d => d.Name == "Development");
    }
    
    [Fact, Order(2)]
    public async Task AddUserTest()
    {
        // Prepare
        _fixture.Db.Users.Add(new User
        {
            Name = "Alex",
            Desc = "Python/C#",
            DepartmentId = 1
        });
        await _fixture.Db.SaveChangesAsync();

        // Execute
        var data = await _fixture.Db.Users.ToListAsync();

        // Assert
        Assert.Single(data);
        Assert.Contains(data, d => d.UserId == 1);
        Assert.Contains(data, d => d.DepartmentId == 1);
        Assert.Contains(data, d => d.Name == "Alex");
        Assert.Contains(data, d => d.Desc == "Python/C#");
    }
}