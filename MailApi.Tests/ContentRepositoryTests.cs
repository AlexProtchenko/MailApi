using System.Threading.Tasks;
using MailApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MailApi.Tests;

public class ContentRepositoryTests : TestBase
{
    [Fact]
    public async Task AddDepartmentTest()
    {
        // Prepare
        using var context = await GetDbContext();
        context.Departments.Add(new Department
        {
            Name = "Development",
        });
        await context.SaveChangesAsync();

        // Execute
        var data = await context.Departments.ToListAsync();

        // Assert
        Assert.Single(data);
        Assert.Contains(data, d => d.DepartmentId == 1);
        Assert.Contains(data, d => d.Name == "Development");
    }
}