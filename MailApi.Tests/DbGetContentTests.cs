using System.Collections.Generic;
using System.Threading.Tasks;
using MailApi.Data.Models;
using MailApi.Data.Repository;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MailApi.Tests;

public class DbGetContentTests : IClassFixture<DbFixture>
{
    private readonly ContentRepository _contentRepository;
    private readonly GetContentRepository _getContentRepository;

    public DbGetContentTests(DbFixture fixture)
    {
        _getContentRepository = fixture.Repo[0];
        _contentRepository = fixture.Repo[1];
    }

    [Fact, Order(1)]
    public Task GetPageUserTest()
    {
        // Prepare
        _contentRepository.Add(new Department
        {
            Name = "Development",
        });
        var users = new List<User>() {
            new User{Name = "Alex", Desc = "Python", DepartmentId = 1},
            new User{Name = "Bob", Desc = "C++", DepartmentId = 1},
            new User{Name = "Kate", Desc = "Java", DepartmentId = 1},
            new User{Name = "Jack", Desc = "C#", DepartmentId = 1}
        };
        foreach (var user in users)
        {
            _contentRepository.Add(user);
        }
        

        // Execute
        var data = _getContentRepository.GetPageableContent(2, 2);

        // Assert
        Assert.Equal("Kate",data[0].Name);
        Assert.Equal("Jack",data[1].Name);
        return Task.CompletedTask;
    }

    [Fact, Order(2)]
    public Task GetUserDevelopmentTest()
    {
        // Execute
        var data = _getContentRepository.GetUserDepartment(new User{DepartmentId = 1});

        // Assert
        Assert.Equal("Alex", data[0].Name);
        Assert.Equal("Bob", data[1].Name);
        Assert.Equal(4, data.Count);
        return Task.CompletedTask;
    }
}