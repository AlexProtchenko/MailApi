using System.Threading.Tasks;
using MailApi.Data.Models;
using MailApi.Data.Repository;
using Xunit;
using Xunit.Extensions.Ordering;

namespace MailApi.Tests;

public class DbContentTests : IClassFixture<DbFixture>
{
    private readonly ContentRepository _contentRepository;
    private readonly GetContentRepository _getContentRepository;

    public DbContentTests(DbFixture fixture)
    {
        _getContentRepository = fixture.Repo[0];
        _contentRepository = fixture.Repo[1];
    }

    [Fact, Order(1)]
    public Task AddDepartmentTest()
    {
        // Prepare
        _contentRepository.Add(new Department
        {
            Name = "Development",
        });

        // Execute
        var data = _getContentRepository.GetAllDepartments();

        // Assert
        Assert.Single(data);
        Assert.Contains(data, d => d.DepartmentId == 1);
        Assert.Contains(data, d => d.Name == "Development");

        _contentRepository.Add(new Department
        {
            Name = "Accounting",
        });
        
        return Task.CompletedTask;

    }

    [Fact, Order(2)]
    public Task AddUserTest()
    {
        // Prepare
        _contentRepository.Add(new User
        {
            Name = "Alex",
            Desc = "Python/C#",
            DepartmentId = 1
        });

        // Execute
        var data = _getContentRepository.GetAllUsers();

        // Assert
        Assert.Single(data);
        Assert.Contains(data, d => d.UserId == 1);
        Assert.Contains(data, d => d.DepartmentId == 1);
        Assert.Contains(data, d => d.Name == "Alex");
        Assert.Contains(data, d => d.Desc == "Python/C#");
        return Task.CompletedTask;
    }

    [Fact, Order(3)]
    public Task UpdateUserTest()
    {
        // Prepare
        _contentRepository.Update(new User
        {
            UserId = 1,
            Name = "Bob",
            Desc = "Counts money well",
            DepartmentId = 2
        });

        // Execute
        var data = _getContentRepository.GetAllUsers();

        // Assert
        Assert.Single(data);
        Assert.Contains(data, d => d.UserId == 1);
        Assert.Contains(data, d => d.DepartmentId == 2);
        Assert.Contains(data, d => d.Name == "Bob");
        Assert.Contains(data, d => d.Desc == "Counts money well");
        return Task.CompletedTask;
    }
    
    [Fact, Order(4)]
    public Task UpdateDepartmentTest()
    {
        // Prepare
        _contentRepository.Update(new Department
        {
            DepartmentId = 1,
            Name = "Marketing",
        });

        // Execute
        var data = _getContentRepository.GetAllDepartments()[0];

        // Assert
        Assert.Equal("Marketing", data.Name);
        return Task.CompletedTask;
    }
    
    [Fact, Order(5)]
    public Task DeleteUserTest()
    {
        // Prepare
        _contentRepository.Delete(new User
        {
            UserId = 1,
        });

        // Execute
        var data = _getContentRepository.GetAllUsers();

        // Assert
        Assert.Empty(data);
        return Task.CompletedTask;
    }
    
    [Fact, Order(6)]
    public Task DeleteDepartmentTest()
    {
        // Prepare
        _contentRepository.Delete(new Department
        {
            DepartmentId = 1,
        });
        
        _contentRepository.Delete(new Department
        {
            DepartmentId = 2,
        });

        // Execute
        var data = _getContentRepository.GetAllDepartments();

        // Assert
        Assert.Empty(data);
        return Task.CompletedTask;
    }
}